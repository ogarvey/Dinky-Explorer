﻿using BrightIdeasSoftware;
using Microsoft.WindowsAPICodePack.Dialogs;
using NAudio.Vorbis;
using NAudio.Wave;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using ThimbleweedLibrary;

//TODO
//Decoding of wimpy files - seem to be 'room' or directories of files + other stuff like walkboxes. Json animation files look like the same format too.


namespace ThimbleweedParkExplorer
{
  public partial class formMain : Form
  {
    private WaveOutEvent outputDevice;
    private WaveStream audioReader;
    private MemoryStream audioDataStream;
    public BundleReader_ggpack Thimble;
    public List<BundleReader_ggpack> Thimbles;
    private SoundBankViewer bankViewer;
    private DinkOptionsPanel dinkOptions;

    public formMain()
    {
      InitializeComponent();
      AllowDrop = true;
      bankAudioListHost.Child = bankViewer = new SoundBankViewer();
      bankViewer.LogEvent += text => log(text);
      DinkOptionsHost.Child = dinkOptions = new DinkOptionsPanel();
      dinkOptions.Log += text => log(text);
      dinkOptions.OnApplyPatch += patchfile => AddFilesToPack(new string[] { patchfile });

      RtMIKeyReader.OnSearchForMonkeyIsland += RtMIKeyReader_OnSearchForMonkeyIsland;
      //Get icon from exe and use for form icon
      Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);

      //Set search box height
      cueTextBox1.AutoSize = false;
      cueTextBox1.Height = panel1.Height;

      //Add 16x16 resources to the imagelist
      var list = ThimbleweedParkExplorer.Properties.Resources.ResourceManager.GetResourceSet(new System.Globalization.CultureInfo("en-us"), true, true);
      foreach (System.Collections.DictionaryEntry img in list)
      {
        //Use img.Value to get the bitmap
        //log(img.Key.ToString());
        var value = img.Value as Bitmap; //Only get images
        if (value != null)
        {
          if (value.Width == 16 && value.Height == 16) //Only add the 16x16 images
            imageList1.Images.Add((string)img.Key, value);
        }
      }

      //Setup image delegates
      InitializeListView();

      //Add info to log box
      richTextBoxLog.Text = Constants.ProgName + " " + Constants.Version + Environment.NewLine + Constants.URL + Environment.NewLine;

      //Set listview background
      objectListView1.SetNativeBackgroundTiledImage(Properties.Resources.listViewBackground);

      EnableDisableControlsContextDependant();

      panelBlank.BringToFront();
    }

    private string RtMIKeyReader_OnSearchForMonkeyIsland()
    {
      OpenFileDialog dialog = new OpenFileDialog();
      dialog.Filter = "Executable File|*.exe";
      if (dialog.ShowDialog() != DialogResult.OK) return "";
      return dialog.FileName;
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (components != null)
        {
          components.Dispose();
        }

        // Dispose stuff here
        if (Thimble != null)
          Thimble.Dispose();

        if (outputDevice != null)
          outputDevice.Dispose();

        if (audioReader != null)
          audioReader.Dispose();

        if (audioDataStream != null)
          audioDataStream.Dispose();
      }
      base.Dispose(disposing);
    }

    //Form closing event
    private void formMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      DisposeAudio();
    }

    //Setup image delegates for the listview
    private void InitializeListView()
    {
      this.columnFilename.ImageGetter = delegate (object rowObject)
      {
        BundleEntry b = (BundleEntry)rowObject;
        //Song s = (Song)rowObject;
        if (b.FileType == BundleEntry.FileTypes.Sound || b.FileType == BundleEntry.FileTypes.Soundbank)
          return Properties.Resources.small_audio;
        else if (b.FileType == BundleEntry.FileTypes.Text)
          return Properties.Resources.small_text;
        else if (b.FileType == BundleEntry.FileTypes.Image)
          return Properties.Resources.small_image;
        else if (b.FileType == BundleEntry.FileTypes.Bnut)
          return Properties.Resources.small_code;
        else if (b.FileType == BundleEntry.FileTypes.GGDict)
          return Properties.Resources.small_code;
        else if (b.FileType == BundleEntry.FileTypes.CompiledScript)
          return Properties.Resources.small_code2;
        else
          return Properties.Resources.small_circle_white;
      };
    }


    //************************************************Button click events*********************************************************************

    //Button open clicked
    private void btnOpen_Click(object sender, EventArgs e)
    {
      if (openFileDialog1.ShowDialog() != DialogResult.OK)
        return;

      try
      {
        EnableDisableControls(false);

        //objectListView1.Items.Clear();

        if (Thimbles != null)
        {
          Thimbles.ForEach(t =>
          {
            objectListView1.RemoveObjects(t.BundleFiles);
            t.Dispose();
          });
          Thimbles.Clear();
        }

        //Clear any existing filters
        objectListView1.ModelFilter = null;

        richTextBoxLog.Clear();

        foreach (var file in openFileDialog1.FileNames)
        {
          var t = new BundleReader_ggpack(file);
          t.LogEvent += this.HandleLogEvent;

          log("Opened " + Path.GetFileNameWithoutExtension(file));

          if (Thimbles == null)
            Thimbles = new List<BundleReader_ggpack>();

          Thimbles.Add(t);
        }
        UpdateOlv1();
      }
      catch (ArgumentException ex)
      {
        log(ex.Message);
        contextMenuView.Items.Clear();
      }
      finally
      {
        EnableDisableControls(true);
      }
    }

    void UpdateOlv1()
    {
      var bundleFiles = Thimbles.SelectMany(t => t.BundleFiles).ToList();
      objectListView1.SetObjects(bundleFiles);
      objectListView1.AutoResizeColumns();
      panelBlank.BringToFront();
      AddFiletypeContextEntries();
      UpdateSaveAllMenu();
      log($"{bundleFiles.Count} files in {Thimbles.Count} bundle{(Thimbles.Count > 1 ? "s" : "")}.");
    }

    //Button view clicked
    private void btnView_Click(object sender, EventArgs e)
    {
      contextMenuView.Show(btnView, new Point(0, btnView.Height));
    }

    //Button save single file clicked
    private void btnSaveFile_Click(object sender, EventArgs e)
    {
      contextMenuSaveFile.Show(btnSaveFile, new Point(0, btnSaveFile.Height));
    }

    //Button SaveAllFiles CLicked
    private void btnSaveAllFiles_Click(object sender, EventArgs e)
    {
      contextMenuSaveAll.Show(btnSaveAllFiles, new Point(0, btnSaveAllFiles.Height));
    }


    //Button about clicked
    private void btnAbout_Click(object sender, EventArgs e)
    {
      formAbout f = new formAbout();
      f.ShowDialog(this);
      f.Dispose();
    }


    //************************************************Save handlers*********************************************************************

    //Save all files handler
    private async void SaveAllHandler(object sender, EventArgs e)
    {
      if (Thimbles == null || Thimbles.SelectMany(t => t.BundleFiles).ToList().Count == 0)
        return;

      var bundleFiles = Thimbles.SelectMany(t => t.BundleFiles).ToList();
      //BundleEntry.FileTypes TargetFileType = BundleEntry.FileTypes.None;
      BundleEntry.FileTypes TargetFileType;
      string SavingMessage = "";

      if (sender.Equals(toolStripSaveAllRaw))
      {
        TargetFileType = BundleEntry.FileTypes.None;
        SavingMessage = "Saving all files...";
      }
      else if (sender.Equals(toolStripSaveAllVisible))
      {
        TargetFileType = BundleEntry.FileTypes.None;
        SavingMessage = "Saving all visible files...";
      }
      else if (sender.Equals(toolStripSaveAllAudio))
      {
        TargetFileType = BundleEntry.FileTypes.Sound;
        SavingMessage = "Saving all audio files...";
      }
      else if (sender.Equals(toolStripSaveAllImages))
      {
        TargetFileType = BundleEntry.FileTypes.Image;
        SavingMessage = "Saving all images...";
      }
      else if (sender.Equals(toolStripSaveAllText))
      {
        TargetFileType = BundleEntry.FileTypes.Text;
        SavingMessage = "Saving all text files...";
      }
      else if (sender.Equals(toolStripSaveAllBnut))
      {
        TargetFileType = BundleEntry.FileTypes.Bnut;
        SavingMessage = "Saving all bnut script files...";
      }
      else
      {
        log("Unknown sender in SaveAllHandler !");
        return;
      }

      using (var openFolder = new CommonOpenFileDialog())
      {
        openFolder.AllowNonFileSystemItems = true;
        openFolder.Multiselect = false;
        openFolder.IsFolderPicker = true;
        openFolder.Title = "Select a folder";

        if (openFolder.ShowDialog() != CommonFileDialogResult.Ok)
          return;

        try
        {
          log($"{SavingMessage} at {DateTime.Now.ToString("HH:mm:ss")}");
          EnableDisableControls(false);
          panelProgress.Visible = true;
          panelProgress.BringToFront();

          progressBar1.Visible = true;
          progressBar1.Maximum = bundleFiles.Count;
          progressBar1.Step = 1;
          progressBar1.Value = 0;

          int progress = 0;
          var progressLock = new object();

          //Save visible uses different technique for dumping
          if (sender.Equals(toolStripSaveAllVisible))
          {
            progressBar1.Maximum = objectListView1.Items.Count; //Count of filtered items
            var bundleFilesDict = bundleFiles.ToDictionary(item => item, item => item);

            ConcurrentBag<BundleEntry> itemsToProcess = new ConcurrentBag<BundleEntry>();

            foreach (var item in objectListView1.FilteredObjects)
            {
              itemsToProcess.Add((BundleEntry)item);
            }

            await Task.Run(() =>
            {
              Parallel.ForEach(itemsToProcess, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, item =>
              {
                if (bundleFilesDict.TryGetValue(item, out var bundleFile))
                {
                  SaveFile(bundleFile, openFolder.FileName, false); // No autodecode for raw dumps
                  lock (progressLock)
                  {
                    progress++;
                    progressBar1.Invoke(new Action(() => progressBar1.Value = progress));
                  }
                }
              });
            });

            // Update progress bar after processing is complete
            progressBar1.Value = progressBar1.Maximum;
          }
          else
          {
            ConcurrentBag<BundleEntry> itemsToProcess = new ConcurrentBag<BundleEntry>(bundleFiles);

            await Task.Run(() =>
            {
              Parallel.ForEach(itemsToProcess, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, item =>
              {
                try
                {
                  if (TargetFileType == BundleEntry.FileTypes.None) // Dump all raw files
                  {
                    SaveFile(item, openFolder.FileName, false);
                  }
                  else if (TargetFileType == BundleEntry.FileTypes.Sound && item.FileType == BundleEntry.FileTypes.Soundbank) // Soundbank
                  {
                    using (MemoryStream ms = new MemoryStream())
                    {
                      item.Extract(ms);
                      ms.Position = 0;
                      var extractor = new FMODBankExtractor(ms);
                      extractor.LogEvent += text => log(text);
                      extractor.SaveAllToDir(openFolder.FileName);
                    }
                  }
                  else if (TargetFileType == BundleEntry.FileTypes.Image && item.FileExtension == "ktxbz") // KTX images, decode to png
                  {
                    byte[] ktxData;
                    using (var memstr = new MemoryStream())
                    {
                      item.Extract(memstr);
                      ktxData = DecompressStream(memstr);
                      ktxData = KtxToPng(new MemoryStream(ktxData));
                      File.WriteAllBytes(Path.Combine(openFolder.FileName, Path.GetFileNameWithoutExtension(item.FileName) + ".png"), ktxData);
                    }
                  }
                  else if (TargetFileType == BundleEntry.FileTypes.Text && item.FileType == BundleEntry.FileTypes.GGDict) // Save ggdict as text
                  {
                    SaveFile(item, openFolder.FileName, true);
                  }
                  else if (TargetFileType == item.FileType) // Other types: Sound/image/text, etc.
                  {
                    SaveFile(item, openFolder.FileName, true);
                  }

                  // Update progress safely
                  lock (progressLock)
                  {
                    progress++;
                    progressBar1.Invoke(new Action(() => progressBar1.Value = progress));
                  }
                }
                catch (Exception ex)
                {
                  // Log or handle the exception as needed
                  log($"Error processing item: {ex.Message}");
                }
              });
            });
          }

          log($"...done! at {DateTime.Now.ToString("HH:mm:ss")}");
          progressBar1.Invoke(new Action(() => progressBar1.Value = progressBar1.Maximum));
        }
        finally
        {
          EnableDisableControls(true);
          progressBar1.Visible = false;
          panelProgress.Visible = false;
        }
      }
    }

    private void SaveFile(BundleEntry bundleFile, string outputFileName, bool v)
    {
      var pathAndFileName = Path.Combine(outputFileName, bundleFile.FileName);
      using (Stream file = File.Create(pathAndFileName))
      {
        bundleFile.Extract(file, v);
      }
    }

    //Save single file handler
    private void SaveFileAsHandler(object sender, EventArgs e)
    {
      if (Thimbles == null || Thimbles.SelectMany(t => t.BundleFiles).ToList().Count == 0 || objectListView1.SelectedIndex == -1)
        return;

      saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(((BundleEntry)objectListView1.SelectedObject).FileName);

      if (sender.Equals(toolStripSaveFileAsAudio))
      {
        saveFileDialog1.Filter = "Audio Files|*.ogg";
      }
      else if (sender.Equals(toolStripSaveFileAsImage))
      {
        saveFileDialog1.Filter = "Png Images (*.png)|*.png|Ktx Images (*.ktx)|*.ktx";
      }
      else if (sender.Equals(toolStripSaveFileAsText))
      {
        saveFileDialog1.Filter = "Text Files|*.txt";
      }
      else if (sender.Equals(toolStripSaveFileRaw))
      {
        saveFileDialog1.Filter = "All Files|*.*";
        saveFileDialog1.FileName = ((BundleEntry)objectListView1.SelectedObject).FileName; //Keep file ext for raw dump
      }
      else
      {
        log("Unknown sender in SaveFileAs !");
        return;
      }

      if (saveFileDialog1.ShowDialog() != DialogResult.OK)
        return;

      int index = Thimbles.SelectMany(t => t.BundleFiles).ToList().IndexOf((BundleEntry)objectListView1.SelectedObject);
      var bundleFile = Thimbles.SelectMany(t => t.BundleFiles).ToList()[index];
      try
      {
        if (bundleFile.FileExtension == "ktxbz")
        {
          byte[] ktxData;
          using (var memstr = new MemoryStream())
          {
            bundleFile.Extract(memstr);
            ktxData = DecompressStream(memstr);
          }

          if (saveFileDialog1.FileName.ToLowerInvariant().EndsWith(".png"))
          {
            ktxData = KtxToPng(new MemoryStream(ktxData));
          }

          File.WriteAllBytes(saveFileDialog1.FileName, ktxData);
        }
        else
        {
          log("Saving file " + saveFileDialog1.FileName);
          EnableDisableControls(false);
          Thimble.SaveFile(index, saveFileDialog1.FileName, !sender.Equals(toolStripSaveFileRaw)); //If raw dump dont autodecode
        }
      }
      finally
      {
        EnableDisableControls(true);
      }
    }



    //************************************************Audio stuff*********************************************************************

    //Button sound play clicked
    private void btnSoundPlay_Click(object sender, EventArgs e)
    {
      if (Thimble == null || Thimble.BundleFiles.Count == 0 || objectListView1.SelectedIndex == -1)
        return;

      int index = Thimble.BundleFiles.IndexOf((BundleEntry)objectListView1.SelectedObject);

      if (Thimble.BundleFiles[index].FileType != BundleEntry.FileTypes.Sound)
        return;

      DisposeAudio();

      audioDataStream = new MemoryStream();
      Thimble.SaveFileToStream(index, audioDataStream);
      outputDevice = new WaveOutEvent();

      if (Thimble.BundleFiles[index].FileExtension == "ogg")
      {
        audioReader = new VorbisWaveReader(audioDataStream);
      }
      else if (Thimble.BundleFiles[index].FileExtension == "wav")
      {
        audioReader = new WaveFileReader(audioDataStream);
      }
      else throw new InvalidOperationException("Not a correct audio file type.");

      outputDevice.Init(audioReader);
      labelSoundProgress.Text = String.Format("{0:00}:{1:00} / {2:00}:{3:00}", 0, 0, (int)audioReader.TotalTime.TotalMinutes, audioReader.TotalTime.Seconds);
      outputDevice.Play();
    }

    //Button sound stop clicked
    private void btnSoundStop_Click(object sender, EventArgs e)
    {
      DisposeAudio();
    }

    //Button sound pause clicked
    private void btnSoundPause_Click(object sender, EventArgs e)
    {
      if (outputDevice != null)
      {
        if (outputDevice.PlaybackState == PlaybackState.Playing) outputDevice.Pause();
        else if (outputDevice.PlaybackState == PlaybackState.Paused) outputDevice.Play();
      }
    }

    //Dispose of all audio resources
    private void DisposeAudio()
    {
      if (outputDevice != null)
      {
        if (outputDevice.PlaybackState == PlaybackState.Playing) outputDevice.Stop();
        outputDevice.Dispose();
        outputDevice = null;
      }
      if (audioReader != null)
      {
        audioReader.Dispose();
        audioReader = null;
      }
      if (audioDataStream != null)
      {
        audioDataStream.Dispose();
        audioDataStream = null;
      }

      labelSoundProgress.Text = "";
    }

    //Timer tick event
    private void timer1_Tick(object sender, EventArgs e)
    {
      if (outputDevice != null && audioReader != null)
      {
        TimeSpan currentTime = (outputDevice.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : audioReader.CurrentTime;
        trackBarSound.Value = Math.Min(trackBarSound.Maximum, (int)(100 * currentTime.TotalSeconds / audioReader.TotalTime.TotalSeconds));
        labelSoundProgress.Text = String.Format("{0:00}:{1:00} / {2:00}:{3:00}", (int)currentTime.TotalMinutes, currentTime.Seconds, (int)audioReader.TotalTime.TotalMinutes, audioReader.TotalTime.Seconds);
      }
      else
      {
        trackBarSound.Value = 0;
      }
    }

    //Sound trackbar scroll event
    private void trackBarSound_Scroll(object sender, EventArgs e)
    {
      if (outputDevice != null && audioReader != null)
      {
        TimeSpan temp = TimeSpan.FromSeconds(audioReader.TotalTime.TotalSeconds * trackBarSound.Value / 100.0);
        if (temp != null && temp < audioReader.TotalTime)
          audioReader.CurrentTime = temp;
      }
    }





    //************************************************Everything else*********************************************************************


    //Handle log event from other class
    private void HandleLogEvent(string Message) => log(Message);

    //Log string to the textbox
    private void log(string logText)
    {
      if (richTextBoxLog.InvokeRequired)
      {
        richTextBoxLog.Invoke(new Action<string>(log), logText);
      }
      else
      {
        richTextBoxLog.AppendText(logText + Environment.NewLine);
      }
    }

    //Enable/disable controls depending on param
    private void EnableDisableControls(bool Value)
    {
      btnOpen.Enabled = Value;
      btnView.Enabled = Value;
      btnSaveFile.Enabled = Value;
      btnSaveAllFiles.Enabled = Value;
      btnAbout.Enabled = Value;
      cueTextBox1.Enabled = Value;
      objectListView1.Enabled = Value;

      if (Value == true)
        EnableDisableControlsContextDependant();
    }

    //Enable/disable controls depending on the context - itemcount, filetypes in file etc
    private void EnableDisableControlsContextDependant()
    {
      if (objectListView1.GetItemCount() > 0)
        btnSaveAllFiles.Enabled = true;
      else
        btnSaveAllFiles.Enabled = false;

      btnSaveFile.Enabled = objectListView1.SelectedIndex != -1;

      if (objectListView1.SelectedIndex != -1)
      {
        //Different save context menu items make visible
        toolStripSaveFileAsAudio.Visible = ((BundleEntry)objectListView1.SelectedObject).FileType == BundleEntry.FileTypes.Sound;
        toolStripSaveFileAsImage.Visible = ((BundleEntry)objectListView1.SelectedObject).FileType == BundleEntry.FileTypes.Image;
        toolStripSaveFileAsText.Visible = ((BundleEntry)objectListView1.SelectedObject).FileType == BundleEntry.FileTypes.Text ||
            ((BundleEntry)objectListView1.SelectedObject).FileType == BundleEntry.FileTypes.Bnut ||
            ((BundleEntry)objectListView1.SelectedObject).FileType == BundleEntry.FileTypes.GGDict;
      }
    }

    //Add the appropriate filetypes to the view contextmenu
    private void AddFiletypeContextEntries()
    {
      contextMenuView.Items.Clear();

      //Add all files and make it checked
      var menuItem = contextMenuView.Items.Add(Constants.AllFiles_ContextMenu);
      ((ToolStripMenuItem)menuItem).Checked = true;

      var entries = Thimbles.SelectMany(t => t.BundleFiles).Select(x => x.FileExtension).Distinct().ToList();
      entries.Sort();
      entries.Insert(0, "-"); //Add the separator

      //Loop through and add the strings from the list
      foreach (string entry in entries)
        contextMenuView.Items.Add(entry, Properties.Resources.small_circle_white);

      //Now do the images
      foreach (ToolStripItem item in contextMenuView.Items)
      {
        var temp = Thimbles.SelectMany(t => t.BundleFiles).FirstOrDefault(x => x.FileExtension == item.Text); //get first item that has the same file extension so we can look at its filetype]
        if (temp != null)
        {
          switch (temp.FileType)
          {
            case BundleEntry.FileTypes.Bnut:
              item.Image = Properties.Resources.small_code;
              break;
            case BundleEntry.FileTypes.Image:
              item.Image = Properties.Resources.small_image;
              break;
            case BundleEntry.FileTypes.Sound:
            case BundleEntry.FileTypes.Soundbank:
              item.Image = Properties.Resources.small_audio;
              break;
            case BundleEntry.FileTypes.Text:
              item.Image = Properties.Resources.small_text;
              break;
            case BundleEntry.FileTypes.GGDict:
              item.Image = Properties.Resources.small_code;
              break;
            case BundleEntry.FileTypes.CompiledScript:
              item.Image = Properties.Resources.small_code2;
              break;
          }
        }
      }
    }

    //Parse through all files and enable the appropriate menu if it finds a matching filetype
    private void UpdateSaveAllMenu()
    {
      var bundleFiles = Thimbles.SelectMany(t => t.BundleFiles).ToList();

      if (Thimbles == null || bundleFiles.Count == 0)
      {
        btnSaveAllFiles.Enabled = false;
        return;
      }

      toolStripSaveAllAudio.Visible = false;
      toolStripSaveAllImages.Visible = false;
      toolStripSaveAllText.Visible = false;
      toolStripSaveAllBnut.Visible = false;

      foreach (var file in bundleFiles)
      {
        switch (file.FileType)
        {
          case BundleEntry.FileTypes.Sound:
          case BundleEntry.FileTypes.Soundbank:
            toolStripSaveAllAudio.Visible = true;
            break;
          case BundleEntry.FileTypes.Image:
            toolStripSaveAllImages.Visible = true;
            break;
          case BundleEntry.FileTypes.Text:
          case BundleEntry.FileTypes.GGDict:
            toolStripSaveAllText.Visible = true;
            break;
          case BundleEntry.FileTypes.Bnut:
            toolStripSaveAllBnut.Visible = true;
            break;
        }

        // If all menu items are visible, no need to continue checking
        if (toolStripSaveAllAudio.Visible && toolStripSaveAllImages.Visible && toolStripSaveAllText.Visible && toolStripSaveAllBnut.Visible)
        {
          break;
        }
      }
    }

    //Search textbox changed
    private void cueTextBox1_TextChanged(object sender, EventArgs e)
    {
      objectListView1.ModelFilter = TextMatchFilter.Contains(objectListView1, cueTextBox1.Text);
    }

    //Item in contextMenuView clicked
    private void contextMenuView_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
      ToolStripItem item = e.ClickedItem;

      //Clear the search box
      cueTextBox1.Clear();

      //Check for 'All Files' first
      if (e.ClickedItem.Text == Constants.AllFiles_ContextMenu)
      {
        objectListView1.ModelFilter = null;
      }
      else
      {
        //Filter the listview by extension
        objectListView1.ModelFilter = new ModelFilter(delegate (object x)
        {
          return ((BundleEntry)x).FileExtension == item.Text;
        });
      }

      //First remove check mark from any items that have it currently
      for (int i = 0; i < contextMenuView.Items.Count; i++)
      {
        if (contextMenuView.Items[i] is ToolStripMenuItem) //The separator is a different type
        {
          ((ToolStripMenuItem)contextMenuView.Items[i]).Checked = false;
        }
      }

        //Then make the clicked item checked
        ((ToolStripMenuItem)item).Checked = true;
    }

    System.Diagnostics.Process ViewerProcess = null;

    private byte[] KtxToPng(Stream ktxStream)
    {
      BCnEncoder.Decoder.BcDecoder decoder = new BCnEncoder.Decoder.BcDecoder();
      var image = decoder.Decode(ktxStream);

      for (int i = 0; i < image.Width * image.Height; ++i)
      {
        int base_addr = 4 * i;
        //BGRA to 
        //RGBA
        var temp = image.data[base_addr];
        image.data[base_addr] = image.data[base_addr + 2];
        image.data[base_addr + 2] = temp;
      }

      GCHandle pinnedArray = GCHandle.Alloc(image.data, GCHandleType.Pinned);
      IntPtr pointer = pinnedArray.AddrOfPinnedObject();

      System.Drawing.Bitmap bmp = new Bitmap(image.Width, image.Height, image.Width * 4, System.Drawing.Imaging.PixelFormat.Format32bppArgb, pointer);
      var ms = new MemoryStream();
      bmp.Save(ms, ImageFormat.Png);

      pinnedArray.Free();
      return ms.ToArray();
    }

    private byte[] DecompressStream(MemoryStream ms)
    {
      ms.Position = 2;
      var Decompressed = new MemoryStream();

      try
      {
        using (var decompressedStream = new MemoryStream())
        {
          using (var d = new DeflateStream(ms, CompressionMode.Decompress))
          {
            d.CopyTo(decompressedStream);
          }
          return decompressedStream.ToArray();
        }
      }
      catch (InvalidDataException)
      {
        throw new InvalidOperationException("Unsupported compression method or corrupted data.");
      }
    }

    //Listview selection changed
    private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Thimbles == null || Thimbles.SelectMany(t => t.BundleFiles).ToList().Count == 0 || objectListView1.SelectedIndex == -1)
        return;

      var bundleFiles = Thimbles.SelectMany(t => t.BundleFiles).ToList();

      EnableDisableControlsContextDependant();

      int index = bundleFiles.IndexOf((BundleEntry)objectListView1.SelectedObject);
      var bundleFile = bundleFiles[index];
      if (bundleFile == null)
        return;

      if (ViewerProcess != null && !ViewerProcess.HasExited) ViewerProcess.CloseMainWindow();

      switch (bundleFile.FileType)
      {
        case BundleEntry.FileTypes.Image:
          panelImage.BringToFront();
          using (MemoryStream ms = new MemoryStream())
          {
            //Release resources from old image
            var oldImage = pictureBoxPreview.Image as Bitmap;
            if (oldImage != null)
              ((IDisposable)oldImage).Dispose();

            if (bundleFile.Size == 0)
            {
              pictureBoxPreview.Image = null;
              return;
            }

            bundleFile.Extract(ms);

            Stream imageStream = ms;

            if (bundleFile.FileExtension == "ktxbz")
            {
              try
              {
                imageStream = new MemoryStream(KtxToPng(new MemoryStream(DecompressStream(ms))));
              }
              catch (Exception ex)
              {
                MessageBox.Show("Could not show file: " + ex.Message);
                imageStream = null;
              }
            }

            if (imageStream != null)
            {
              var image = Image.FromStream(imageStream);
              pictureBoxPreview.Image = image;

              //Set scaling mode depending on whether image is larger or smaller than the picturebox. From https://stackoverflow.com/questions/41188806/fit-image-to-picturebox-if-picturebox-is-smaller-than-picture
              var imageSize = pictureBoxPreview.Image.Size;
              var fitSize = pictureBoxPreview.ClientSize;
              pictureBoxPreview.SizeMode = imageSize.Width > fitSize.Width || imageSize.Height > fitSize.Height ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;
            }
          }
          break;

        case BundleEntry.FileTypes.Soundbank:
          {
            bankAudioListHost.BringToFront();
            MemoryStream ms = new MemoryStream();
            bundleFile.Extract(ms);
            ms.Position = 0;
            bankViewer.SetBank(ms);
          }
          break;
        case BundleEntry.FileTypes.Sound:
          panelAudio.BringToFront();
          break;
        case BundleEntry.FileTypes.Text:
          panelText.BringToFront();

          using (MemoryStream ms = new MemoryStream())
          {
            bundleFile.Extract(ms);

            if (bundleFile.FileExtension == "yack" && Thimbles.First().Cryptor.FileVersion == BundleFileVersion.Version_RtMI)
            {
              try
              {
                ms.Position = 0;
                YackDecompiler yack = new YackDecompiler(ms);
                textBoxPreview.Lines = ("Note: This file was decompiled. Not all opcodes are understood!" + yack.ToString()).Split('\n');
              }
              catch (Exception ex)
              {
                textBoxPreview.Lines = new string[] { "could not decompile .yack:", ex.Message };
              }
            }
            else
            {
              string[] tempArray = new string[] { }; //initialise an empty array of strings
              if (Decoders.ExtractText(ms, out tempArray) == true)
              {
                textBoxPreview.Lines = tempArray;
              }
            }

          }
          break;

        case BundleEntry.FileTypes.GGDict:
          panelText.BringToFront();
          using (MemoryStream ms = new MemoryStream())
          {
            bundleFile.Extract(ms, false);

            GGDict dict = new GGDict(ms, Thimbles.First().Cryptor.FileVersion == BundleFileVersion.Version_RtMI);
            string[] lines = dict.ToJsonString().Split('\n').Select(s => s.Trim('\r')).ToArray();
            textBoxPreview.Lines = lines;
          }
          break;

        case BundleEntry.FileTypes.Bnut:
          panelText.BringToFront();
          using (MemoryStream ms = new MemoryStream())
          {
            bundleFile.Extract(ms);
            //Decoders.DecodeBnut(ms);

            string[] tempArray = new string[] { }; //initialise an empty array of strings
            if (Decoders.ExtractText(ms, out tempArray) == true)
            {
              textBoxPreview.Lines = tempArray;
            }
          }
          break;

        case BundleEntry.FileTypes.CompiledScript:
          {
            panelText.BringToFront();

            using (MemoryStream ms = new MemoryStream())
            {
              bundleFile.Extract(ms);
              DinkDisassembler disassembled = new DinkDisassembler(ms);

              DinkOptionsHost.BringToFront();
              dinkOptions.dink = disassembled;
              string decompiled = disassembled.ToString();
            }
          }
          break;
        default:
          panelBlank.BringToFront();

          break;
      }
    }

    //Listview double clicked
    private void objectListView1_DoubleClick(object sender, EventArgs e)
    {
      if (Thimble == null || Thimble.BundleFiles.Count == 0 || objectListView1.SelectedIndex == -1)
        return;

      int index = Thimble.BundleFiles.IndexOf((BundleEntry)objectListView1.SelectedObject);

      if (Thimble.BundleFiles[index].FileType == BundleEntry.FileTypes.Sound || Thimble.BundleFiles[index].FileType == BundleEntry.FileTypes.Soundbank)
      {
        btnSoundPlay.PerformClick();
      }
    }

    private void objectListView1_DragEnter(object sender, DragEventArgs e)
    {
      e.Effect = DragDropEffects.All;
    }

    private void formMain_DragDrop(object sender, DragEventArgs e)
    {
      if (Thimble == null) return;

      var data = e.Data.GetData(DataFormats.FileDrop);
      if (data == null || !(data is string[] files)) return;
      AddFilesToPack(files);
    }

    private void AddFilesToPack(string[] files)
    {
      objectListView1.RemoveObjects(Thimble.BundleFiles);
      try
      {
        foreach (var file in files)
        {
          if (Path.GetExtension(file).ToLower().TrimStart('.') == "dinkypatch")
          {
            RtmiPatchScripts(file);
          }
          else
          {
            log($"Adding file \"{file}\"");
            Thimble.AddFile(file);
          }
        }

        log($"Saving pack file.");
        Thimble.Save();
        log($"Pack file saved.");
      }
      catch (Exception ex)
      {
        log($"error packing files: {ex.Message}");
      }

      UpdateOlv1();
    }

    private void RtmiPatchScripts(string file)
    {
      if (Thimble.Cryptor.FileVersion != BundleFileVersion.Version_RtMI)
      {
        log("Patch files are only supported for RtMI");
        return;
      }

      log($"Applying patch {file}...");
      DinkyPatchFile patchfile = null;
      try
      {
        patchfile = Newtonsoft.Json.JsonConvert.DeserializeObject(File.ReadAllText(file), typeof(DinkyPatchFile)) as DinkyPatchFile;
      }
      catch (Exception ex)
      {
        log($"could not load patch file: {ex.Message}");
        return;
      }

      log($"patch: {patchfile.title} by {patchfile.author}:\n\t{patchfile.description}");

      using (var ms = new MemoryStream())
      {
        var weirddink = Thimble.BundleFiles.Where(b => b.FileName.ToLower() == "weird.dink").FirstOrDefault();
        if (weirddink == null)
        {
          log("Could not find file \"Weird.dink\". Are you sure you opened the right pack file?");
          return;
        }
        weirddink.Extract(ms);
        ms.Position = 0;

        var originalScriptFile = Thimble.BundleFiles.Where(f => f.FileName.ToLowerInvariant() == "weird.vanilla.dink").FirstOrDefault();
        if (originalScriptFile == null)
        {
          Thimble.AddFile(ms, "Weird.vanilla.dink");
          ms.Position = 0;
        }

        DinkDisassembler dinkFile = new DinkDisassembler(ms);

        try
        {
          patchfile.ApplyPatch(dinkFile);
        }
        catch (Exception ex)
        {
          log($"could not apply patch:\n\t{ex.Message}");
          return;
        }

        log("patch applied successfully.");
        var reassembled = dinkFile.SaveDink();
        Thimble.AddFile(new MemoryStream(reassembled), "Weird.dink");
      }
    }
  }
}