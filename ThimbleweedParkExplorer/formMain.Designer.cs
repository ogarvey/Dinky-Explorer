namespace ThimbleweedParkExplorer
{
    partial class formMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
      openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      richTextBoxLog = new System.Windows.Forms.RichTextBox();
      panel1 = new System.Windows.Forms.Panel();
      cueTextBox1 = new CueTextBox();
      btnAbout = new System.Windows.Forms.Button();
      btnSaveAllFiles = new System.Windows.Forms.Button();
      btnSaveFile = new System.Windows.Forms.Button();
      btnView = new System.Windows.Forms.Button();
      btnOpen = new System.Windows.Forms.Button();
      contextMenuView = new System.Windows.Forms.ContextMenuStrip(components);
      splitContainer1 = new System.Windows.Forms.SplitContainer();
      objectListView1 = new BrightIdeasSoftware.ObjectListView();
      columnFilename = new BrightIdeasSoftware.OLVColumn();
      columnFileextension = new BrightIdeasSoftware.OLVColumn();
      columnOffset = new BrightIdeasSoftware.OLVColumn();
      columnSize = new BrightIdeasSoftware.OLVColumn();
      imageList1 = new System.Windows.Forms.ImageList(components);
      DinkOptionsHost = new System.Windows.Forms.Integration.ElementHost();
      panelAudio = new System.Windows.Forms.Panel();
      labelSoundProgress = new System.Windows.Forms.Label();
      trackBarSound = new System.Windows.Forms.TrackBar();
      btnSoundStop = new System.Windows.Forms.Button();
      btnSoundPause = new System.Windows.Forms.Button();
      btnSoundPlay = new System.Windows.Forms.Button();
      bankAudioListHost = new System.Windows.Forms.Integration.ElementHost();
      panelBlank = new System.Windows.Forms.Panel();
      pictureBox1 = new System.Windows.Forms.PictureBox();
      panelProgress = new System.Windows.Forms.Panel();
      pictureBoxProgress = new System.Windows.Forms.PictureBox();
      panelImage = new System.Windows.Forms.Panel();
      pictureBoxPreview = new System.Windows.Forms.PictureBox();
      panelText = new System.Windows.Forms.Panel();
      textBoxPreview = new System.Windows.Forms.TextBox();
      saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      timer1 = new System.Windows.Forms.Timer(components);
      contextMenuSaveAll = new System.Windows.Forms.ContextMenuStrip(components);
      toolStripSaveAllRaw = new System.Windows.Forms.ToolStripMenuItem();
      toolStripSaveAllVisible = new System.Windows.Forms.ToolStripMenuItem();
      toolStripSaveAllAudio = new System.Windows.Forms.ToolStripMenuItem();
      toolStripSaveAllImages = new System.Windows.Forms.ToolStripMenuItem();
      toolStripSaveAllText = new System.Windows.Forms.ToolStripMenuItem();
      toolStripSaveAllBnut = new System.Windows.Forms.ToolStripMenuItem();
      contextMenuSaveFile = new System.Windows.Forms.ContextMenuStrip(components);
      toolStripSaveFileRaw = new System.Windows.Forms.ToolStripMenuItem();
      toolStripSaveFileAsText = new System.Windows.Forms.ToolStripMenuItem();
      toolStripSaveFileAsImage = new System.Windows.Forms.ToolStripMenuItem();
      toolStripSaveFileAsAudio = new System.Windows.Forms.ToolStripMenuItem();
      progressBar1 = new CustomProgressBar();
      panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
      splitContainer1.Panel1.SuspendLayout();
      splitContainer1.Panel2.SuspendLayout();
      splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)objectListView1).BeginInit();
      panelAudio.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)trackBarSound).BeginInit();
      panelBlank.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
      panelProgress.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBoxProgress).BeginInit();
      panelImage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).BeginInit();
      panelText.SuspendLayout();
      contextMenuSaveAll.SuspendLayout();
      contextMenuSaveFile.SuspendLayout();
      SuspendLayout();
      // 
      // openFileDialog1
      // 
      openFileDialog1.Filter = "Ggpack files|*.ggpack?;*.ggpack??";
      openFileDialog1.Multiselect = true;
      openFileDialog1.ShowReadOnly = true;
      // 
      // richTextBoxLog
      // 
      richTextBoxLog.BackColor = System.Drawing.Color.White;
      richTextBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
      richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Bottom;
      richTextBoxLog.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
      richTextBoxLog.HideSelection = false;
      richTextBoxLog.Location = new System.Drawing.Point(0, 436);
      richTextBoxLog.Margin = new System.Windows.Forms.Padding(4);
      richTextBoxLog.Name = "richTextBoxLog";
      richTextBoxLog.ReadOnly = true;
      richTextBoxLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
      richTextBoxLog.ShowSelectionMargin = true;
      richTextBoxLog.Size = new System.Drawing.Size(894, 68);
      richTextBoxLog.TabIndex = 4;
      richTextBoxLog.Text = "Dinky Explorer\nhttp://quickandeasysoftware.net\n";
      // 
      // panel1
      // 
      panel1.AutoSize = true;
      panel1.Controls.Add(cueTextBox1);
      panel1.Controls.Add(btnAbout);
      panel1.Controls.Add(btnSaveAllFiles);
      panel1.Controls.Add(btnSaveFile);
      panel1.Controls.Add(btnView);
      panel1.Controls.Add(btnOpen);
      panel1.Dock = System.Windows.Forms.DockStyle.Top;
      panel1.Location = new System.Drawing.Point(0, 0);
      panel1.Margin = new System.Windows.Forms.Padding(4);
      panel1.MinimumSize = new System.Drawing.Size(0, 55);
      panel1.Name = "panel1";
      panel1.Size = new System.Drawing.Size(894, 55);
      panel1.TabIndex = 0;
      // 
      // cueTextBox1
      // 
      cueTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      cueTextBox1.Cue = "";
      cueTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      cueTextBox1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
      cueTextBox1.Location = new System.Drawing.Point(434, 0);
      cueTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
      cueTextBox1.Name = "cueTextBox1";
      cueTextBox1.Size = new System.Drawing.Size(460, 43);
      cueTextBox1.TabIndex = 13;
      cueTextBox1.TextChanged += cueTextBox1_TextChanged;
      // 
      // btnAbout
      // 
      btnAbout.AutoSize = true;
      btnAbout.Dock = System.Windows.Forms.DockStyle.Left;
      btnAbout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 227, 228);
      btnAbout.FlatAppearance.BorderSize = 0;
      btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(201, 224, 247);
      btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 239, 247);
      btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      btnAbout.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
      btnAbout.Image = (System.Drawing.Image)resources.GetObject("btnAbout.Image");
      btnAbout.Location = new System.Drawing.Point(346, 0);
      btnAbout.Margin = new System.Windows.Forms.Padding(4);
      btnAbout.Name = "btnAbout";
      btnAbout.Size = new System.Drawing.Size(88, 55);
      btnAbout.TabIndex = 12;
      btnAbout.Text = "About";
      btnAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      btnAbout.UseVisualStyleBackColor = true;
      btnAbout.Click += btnAbout_Click;
      // 
      // btnSaveAllFiles
      // 
      btnSaveAllFiles.AutoSize = true;
      btnSaveAllFiles.Dock = System.Windows.Forms.DockStyle.Left;
      btnSaveAllFiles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 227, 228);
      btnSaveAllFiles.FlatAppearance.BorderSize = 0;
      btnSaveAllFiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(201, 224, 247);
      btnSaveAllFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 239, 247);
      btnSaveAllFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      btnSaveAllFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
      btnSaveAllFiles.Image = (System.Drawing.Image)resources.GetObject("btnSaveAllFiles.Image");
      btnSaveAllFiles.Location = new System.Drawing.Point(264, 0);
      btnSaveAllFiles.Margin = new System.Windows.Forms.Padding(4);
      btnSaveAllFiles.Name = "btnSaveAllFiles";
      btnSaveAllFiles.Size = new System.Drawing.Size(82, 55);
      btnSaveAllFiles.TabIndex = 11;
      btnSaveAllFiles.Text = "Save All Files";
      btnSaveAllFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      btnSaveAllFiles.UseVisualStyleBackColor = true;
      btnSaveAllFiles.Click += btnSaveAllFiles_Click;
      // 
      // btnSaveFile
      // 
      btnSaveFile.AutoSize = true;
      btnSaveFile.Dock = System.Windows.Forms.DockStyle.Left;
      btnSaveFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 227, 228);
      btnSaveFile.FlatAppearance.BorderSize = 0;
      btnSaveFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(201, 224, 247);
      btnSaveFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 239, 247);
      btnSaveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      btnSaveFile.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
      btnSaveFile.Image = (System.Drawing.Image)resources.GetObject("btnSaveFile.Image");
      btnSaveFile.Location = new System.Drawing.Point(176, 0);
      btnSaveFile.Margin = new System.Windows.Forms.Padding(4);
      btnSaveFile.Name = "btnSaveFile";
      btnSaveFile.Size = new System.Drawing.Size(88, 55);
      btnSaveFile.TabIndex = 10;
      btnSaveFile.Text = "Save File";
      btnSaveFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      btnSaveFile.UseVisualStyleBackColor = true;
      btnSaveFile.Click += btnSaveFile_Click;
      // 
      // btnView
      // 
      btnView.AutoSize = true;
      btnView.Dock = System.Windows.Forms.DockStyle.Left;
      btnView.Enabled = false;
      btnView.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 227, 228);
      btnView.FlatAppearance.BorderSize = 0;
      btnView.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(201, 224, 247);
      btnView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 239, 247);
      btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      btnView.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
      btnView.Image = (System.Drawing.Image)resources.GetObject("btnView.Image");
      btnView.Location = new System.Drawing.Point(88, 0);
      btnView.Margin = new System.Windows.Forms.Padding(4);
      btnView.Name = "btnView";
      btnView.Size = new System.Drawing.Size(88, 55);
      btnView.TabIndex = 3;
      btnView.Text = "View";
      btnView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      btnView.UseVisualStyleBackColor = true;
      btnView.Click += btnView_Click;
      // 
      // btnOpen
      // 
      btnOpen.AutoSize = true;
      btnOpen.Dock = System.Windows.Forms.DockStyle.Left;
      btnOpen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 227, 228);
      btnOpen.FlatAppearance.BorderSize = 0;
      btnOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(201, 224, 247);
      btnOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 239, 247);
      btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      btnOpen.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
      btnOpen.Image = (System.Drawing.Image)resources.GetObject("btnOpen.Image");
      btnOpen.Location = new System.Drawing.Point(0, 0);
      btnOpen.Margin = new System.Windows.Forms.Padding(4);
      btnOpen.Name = "btnOpen";
      btnOpen.Size = new System.Drawing.Size(88, 55);
      btnOpen.TabIndex = 2;
      btnOpen.Text = "Open";
      btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      btnOpen.UseVisualStyleBackColor = true;
      btnOpen.Click += btnOpen_Click;
      // 
      // contextMenuView
      // 
      contextMenuView.Font = new System.Drawing.Font("Segoe UI", 9F);
      contextMenuView.Name = "contextMenuView";
      contextMenuView.Size = new System.Drawing.Size(61, 4);
      contextMenuView.ItemClicked += contextMenuView_ItemClicked;
      // 
      // splitContainer1
      // 
      splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      splitContainer1.Location = new System.Drawing.Point(0, 55);
      splitContainer1.Margin = new System.Windows.Forms.Padding(4);
      splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      splitContainer1.Panel1.Controls.Add(objectListView1);
      splitContainer1.Panel1MinSize = 400;
      // 
      // splitContainer1.Panel2
      // 
      splitContainer1.Panel2.Controls.Add(DinkOptionsHost);
      splitContainer1.Panel2.Controls.Add(panelAudio);
      splitContainer1.Panel2.Controls.Add(bankAudioListHost);
      splitContainer1.Panel2.Controls.Add(panelBlank);
      splitContainer1.Panel2.Controls.Add(panelProgress);
      splitContainer1.Panel2.Controls.Add(panelImage);
      splitContainer1.Panel2.Controls.Add(panelText);
      splitContainer1.Panel2MinSize = 200;
      splitContainer1.Size = new System.Drawing.Size(894, 381);
      splitContainer1.SplitterDistance = 605;
      splitContainer1.SplitterWidth = 5;
      splitContainer1.TabIndex = 9;
      // 
      // objectListView1
      // 
      objectListView1.AllColumns.Add(columnFilename);
      objectListView1.AllColumns.Add(columnFileextension);
      objectListView1.AllColumns.Add(columnOffset);
      objectListView1.AllColumns.Add(columnSize);
      objectListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      objectListView1.CellEditUseWholeCell = false;
      objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnFilename, columnFileextension, columnOffset, columnSize });
      objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
      objectListView1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
      objectListView1.FullRowSelect = true;
      objectListView1.Location = new System.Drawing.Point(0, 0);
      objectListView1.Margin = new System.Windows.Forms.Padding(4);
      objectListView1.Name = "objectListView1";
      objectListView1.OverlayImage.Transparency = 180;
      objectListView1.ShowGroups = false;
      objectListView1.Size = new System.Drawing.Size(603, 379);
      objectListView1.SmallImageList = imageList1;
      objectListView1.TabIndex = 6;
      objectListView1.UseCompatibleStateImageBehavior = false;
      objectListView1.UseFiltering = true;
      objectListView1.View = System.Windows.Forms.View.Details;
      objectListView1.SelectedIndexChanged += objectListView1_SelectedIndexChanged;
      objectListView1.DoubleClick += objectListView1_DoubleClick;
      // 
      // columnFilename
      // 
      columnFilename.AspectName = "FileName";
      columnFilename.Groupable = false;
      columnFilename.MinimumWidth = 80;
      columnFilename.Text = "Name";
      columnFilename.Width = 100;
      // 
      // columnFileextension
      // 
      columnFileextension.AspectName = "FileExtension";
      columnFileextension.MinimumWidth = 120;
      columnFileextension.Text = "Type";
      columnFileextension.Width = 120;
      // 
      // columnOffset
      // 
      columnOffset.AspectName = "Offset";
      columnOffset.MinimumWidth = 50;
      columnOffset.Text = "Offset";
      columnOffset.Width = 80;
      // 
      // columnSize
      // 
      columnSize.AspectName = "Size";
      columnSize.FillsFreeSpace = true;
      columnSize.MinimumWidth = 50;
      columnSize.Text = "Size";
      columnSize.Width = 80;
      // 
      // imageList1
      // 
      imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
      imageList1.ImageSize = new System.Drawing.Size(16, 16);
      imageList1.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // DinkOptionsHost
      // 
      DinkOptionsHost.Dock = System.Windows.Forms.DockStyle.Fill;
      DinkOptionsHost.Location = new System.Drawing.Point(0, 0);
      DinkOptionsHost.Margin = new System.Windows.Forms.Padding(0);
      DinkOptionsHost.Name = "DinkOptionsHost";
      DinkOptionsHost.Size = new System.Drawing.Size(282, 379);
      DinkOptionsHost.TabIndex = 15;
      DinkOptionsHost.Text = "elementHost1";
      // 
      // panelAudio
      // 
      panelAudio.Controls.Add(labelSoundProgress);
      panelAudio.Controls.Add(trackBarSound);
      panelAudio.Controls.Add(btnSoundStop);
      panelAudio.Controls.Add(btnSoundPause);
      panelAudio.Controls.Add(btnSoundPlay);
      panelAudio.Dock = System.Windows.Forms.DockStyle.Fill;
      panelAudio.Location = new System.Drawing.Point(0, 0);
      panelAudio.Margin = new System.Windows.Forms.Padding(4);
      panelAudio.Name = "panelAudio";
      panelAudio.Size = new System.Drawing.Size(282, 379);
      panelAudio.TabIndex = 1;
      // 
      // labelSoundProgress
      // 
      labelSoundProgress.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
      labelSoundProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
      labelSoundProgress.Location = new System.Drawing.Point(0, 112);
      labelSoundProgress.Name = "labelSoundProgress";
      labelSoundProgress.Size = new System.Drawing.Size(279, 31);
      labelSoundProgress.TabIndex = 14;
      labelSoundProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // trackBarSound
      // 
      trackBarSound.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
      trackBarSound.AutoSize = false;
      trackBarSound.Location = new System.Drawing.Point(6, 151);
      trackBarSound.Maximum = 100;
      trackBarSound.Name = "trackBarSound";
      trackBarSound.Size = new System.Drawing.Size(276, 33);
      trackBarSound.TabIndex = 13;
      trackBarSound.TickStyle = System.Windows.Forms.TickStyle.None;
      trackBarSound.Scroll += trackBarSound_Scroll;
      // 
      // btnSoundStop
      // 
      btnSoundStop.Anchor = System.Windows.Forms.AnchorStyles.Left;
      btnSoundStop.AutoSize = true;
      btnSoundStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      btnSoundStop.FlatAppearance.BorderSize = 0;
      btnSoundStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      btnSoundStop.Location = new System.Drawing.Point(171, 181);
      btnSoundStop.Name = "btnSoundStop";
      btnSoundStop.Size = new System.Drawing.Size(6, 6);
      btnSoundStop.TabIndex = 12;
      btnSoundStop.UseVisualStyleBackColor = true;
      btnSoundStop.Click += btnSoundStop_Click;
      // 
      // btnSoundPause
      // 
      btnSoundPause.Anchor = System.Windows.Forms.AnchorStyles.Left;
      btnSoundPause.AutoSize = true;
      btnSoundPause.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      btnSoundPause.FlatAppearance.BorderSize = 0;
      btnSoundPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      btnSoundPause.Location = new System.Drawing.Point(119, 181);
      btnSoundPause.Name = "btnSoundPause";
      btnSoundPause.Size = new System.Drawing.Size(6, 6);
      btnSoundPause.TabIndex = 11;
      btnSoundPause.UseVisualStyleBackColor = true;
      btnSoundPause.Click += btnSoundPause_Click;
      // 
      // btnSoundPlay
      // 
      btnSoundPlay.Anchor = System.Windows.Forms.AnchorStyles.Left;
      btnSoundPlay.AutoSize = true;
      btnSoundPlay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      btnSoundPlay.FlatAppearance.BorderSize = 0;
      btnSoundPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      btnSoundPlay.Location = new System.Drawing.Point(69, 181);
      btnSoundPlay.Name = "btnSoundPlay";
      btnSoundPlay.Size = new System.Drawing.Size(6, 6);
      btnSoundPlay.TabIndex = 0;
      btnSoundPlay.UseVisualStyleBackColor = true;
      btnSoundPlay.Click += btnSoundPlay_Click;
      // 
      // bankAudioListHost
      // 
      bankAudioListHost.Dock = System.Windows.Forms.DockStyle.Fill;
      bankAudioListHost.Location = new System.Drawing.Point(0, 0);
      bankAudioListHost.Name = "bankAudioListHost";
      bankAudioListHost.Size = new System.Drawing.Size(282, 379);
      bankAudioListHost.TabIndex = 15;
      bankAudioListHost.Text = "elementHost1";
      // 
      // panelBlank
      // 
      panelBlank.Controls.Add(pictureBox1);
      panelBlank.Dock = System.Windows.Forms.DockStyle.Fill;
      panelBlank.Location = new System.Drawing.Point(0, 0);
      panelBlank.Margin = new System.Windows.Forms.Padding(4);
      panelBlank.Name = "panelBlank";
      panelBlank.Size = new System.Drawing.Size(282, 379);
      panelBlank.TabIndex = 0;
      // 
      // pictureBox1
      // 
      pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
      pictureBox1.InitialImage = (System.Drawing.Image)resources.GetObject("pictureBox1.InitialImage");
      pictureBox1.Location = new System.Drawing.Point(0, 0);
      pictureBox1.Margin = new System.Windows.Forms.Padding(4);
      pictureBox1.Name = "pictureBox1";
      pictureBox1.Size = new System.Drawing.Size(282, 379);
      pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      pictureBox1.TabIndex = 0;
      pictureBox1.TabStop = false;
      // 
      // panelProgress
      // 
      panelProgress.Controls.Add(pictureBoxProgress);
      panelProgress.Dock = System.Windows.Forms.DockStyle.Fill;
      panelProgress.Location = new System.Drawing.Point(0, 0);
      panelProgress.Margin = new System.Windows.Forms.Padding(4);
      panelProgress.Name = "panelProgress";
      panelProgress.Size = new System.Drawing.Size(282, 379);
      panelProgress.TabIndex = 4;
      // 
      // pictureBoxProgress
      // 
      pictureBoxProgress.Dock = System.Windows.Forms.DockStyle.Fill;
      pictureBoxProgress.Image = (System.Drawing.Image)resources.GetObject("pictureBoxProgress.Image");
      pictureBoxProgress.Location = new System.Drawing.Point(0, 0);
      pictureBoxProgress.Margin = new System.Windows.Forms.Padding(4);
      pictureBoxProgress.Name = "pictureBoxProgress";
      pictureBoxProgress.Size = new System.Drawing.Size(282, 379);
      pictureBoxProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      pictureBoxProgress.TabIndex = 0;
      pictureBoxProgress.TabStop = false;
      // 
      // panelImage
      // 
      panelImage.Controls.Add(pictureBoxPreview);
      panelImage.Dock = System.Windows.Forms.DockStyle.Fill;
      panelImage.Location = new System.Drawing.Point(0, 0);
      panelImage.Margin = new System.Windows.Forms.Padding(4);
      panelImage.Name = "panelImage";
      panelImage.Size = new System.Drawing.Size(282, 379);
      panelImage.TabIndex = 3;
      // 
      // pictureBoxPreview
      // 
      pictureBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
      pictureBoxPreview.Location = new System.Drawing.Point(0, 0);
      pictureBoxPreview.Name = "pictureBoxPreview";
      pictureBoxPreview.Size = new System.Drawing.Size(282, 379);
      pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      pictureBoxPreview.TabIndex = 0;
      pictureBoxPreview.TabStop = false;
      // 
      // panelText
      // 
      panelText.Controls.Add(textBoxPreview);
      panelText.Dock = System.Windows.Forms.DockStyle.Fill;
      panelText.Location = new System.Drawing.Point(0, 0);
      panelText.Margin = new System.Windows.Forms.Padding(4);
      panelText.Name = "panelText";
      panelText.Size = new System.Drawing.Size(282, 379);
      panelText.TabIndex = 2;
      // 
      // textBoxPreview
      // 
      textBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
      textBoxPreview.Location = new System.Drawing.Point(0, 0);
      textBoxPreview.Multiline = true;
      textBoxPreview.Name = "textBoxPreview";
      textBoxPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      textBoxPreview.Size = new System.Drawing.Size(282, 379);
      textBoxPreview.TabIndex = 0;
      // 
      // timer1
      // 
      timer1.Enabled = true;
      timer1.Interval = 500;
      timer1.Tick += timer1_Tick;
      // 
      // contextMenuSaveAll
      // 
      contextMenuSaveAll.Font = new System.Drawing.Font("Segoe UI", 9F);
      contextMenuSaveAll.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripSaveAllRaw, toolStripSaveAllVisible, toolStripSaveAllAudio, toolStripSaveAllImages, toolStripSaveAllText, toolStripSaveAllBnut });
      contextMenuSaveAll.Name = "contextMenuView";
      contextMenuSaveAll.Size = new System.Drawing.Size(239, 136);
      // 
      // toolStripSaveAllRaw
      // 
      toolStripSaveAllRaw.Name = "toolStripSaveAllRaw";
      toolStripSaveAllRaw.Size = new System.Drawing.Size(238, 22);
      toolStripSaveAllRaw.Text = "Save all files (raw dump)";
      toolStripSaveAllRaw.Click += SaveAllHandler;
      // 
      // toolStripSaveAllVisible
      // 
      toolStripSaveAllVisible.Name = "toolStripSaveAllVisible";
      toolStripSaveAllVisible.Size = new System.Drawing.Size(238, 22);
      toolStripSaveAllVisible.Text = "Save all visible files (raw dump)";
      toolStripSaveAllVisible.Click += SaveAllHandler;
      // 
      // toolStripSaveAllAudio
      // 
      toolStripSaveAllAudio.Name = "toolStripSaveAllAudio";
      toolStripSaveAllAudio.Size = new System.Drawing.Size(238, 22);
      toolStripSaveAllAudio.Text = "Save all audio";
      toolStripSaveAllAudio.Click += SaveAllHandler;
      // 
      // toolStripSaveAllImages
      // 
      toolStripSaveAllImages.Name = "toolStripSaveAllImages";
      toolStripSaveAllImages.Size = new System.Drawing.Size(238, 22);
      toolStripSaveAllImages.Text = "Save all images";
      toolStripSaveAllImages.Click += SaveAllHandler;
      // 
      // toolStripSaveAllText
      // 
      toolStripSaveAllText.Name = "toolStripSaveAllText";
      toolStripSaveAllText.Size = new System.Drawing.Size(238, 22);
      toolStripSaveAllText.Tag = "";
      toolStripSaveAllText.Text = "Save all text";
      toolStripSaveAllText.Click += SaveAllHandler;
      // 
      // toolStripSaveAllBnut
      // 
      toolStripSaveAllBnut.Name = "toolStripSaveAllBnut";
      toolStripSaveAllBnut.Size = new System.Drawing.Size(238, 22);
      toolStripSaveAllBnut.Tag = "";
      toolStripSaveAllBnut.Text = "Save all bnut scripts";
      toolStripSaveAllBnut.Click += SaveAllHandler;
      // 
      // contextMenuSaveFile
      // 
      contextMenuSaveFile.Font = new System.Drawing.Font("Segoe UI", 9F);
      contextMenuSaveFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripSaveFileRaw, toolStripSaveFileAsText, toolStripSaveFileAsImage, toolStripSaveFileAsAudio });
      contextMenuSaveFile.Name = "contextMenuView";
      contextMenuSaveFile.Size = new System.Drawing.Size(164, 92);
      // 
      // toolStripSaveFileRaw
      // 
      toolStripSaveFileRaw.Name = "toolStripSaveFileRaw";
      toolStripSaveFileRaw.Size = new System.Drawing.Size(163, 22);
      toolStripSaveFileRaw.Text = "As is (raw dump)";
      toolStripSaveFileRaw.Click += SaveFileAsHandler;
      // 
      // toolStripSaveFileAsText
      // 
      toolStripSaveFileAsText.Name = "toolStripSaveFileAsText";
      toolStripSaveFileAsText.Size = new System.Drawing.Size(163, 22);
      toolStripSaveFileAsText.Text = "As text";
      toolStripSaveFileAsText.Click += SaveFileAsHandler;
      // 
      // toolStripSaveFileAsImage
      // 
      toolStripSaveFileAsImage.Name = "toolStripSaveFileAsImage";
      toolStripSaveFileAsImage.Size = new System.Drawing.Size(163, 22);
      toolStripSaveFileAsImage.Text = "As Image";
      toolStripSaveFileAsImage.Click += SaveFileAsHandler;
      // 
      // toolStripSaveFileAsAudio
      // 
      toolStripSaveFileAsAudio.Name = "toolStripSaveFileAsAudio";
      toolStripSaveFileAsAudio.Size = new System.Drawing.Size(163, 22);
      toolStripSaveFileAsAudio.Text = "As audio";
      toolStripSaveFileAsAudio.Click += SaveFileAsHandler;
      // 
      // progressBar1
      // 
      progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
      progressBar1.ForeColor = System.Drawing.Color.FromArgb(255, 184, 39);
      progressBar1.Location = new System.Drawing.Point(0, 504);
      progressBar1.Name = "progressBar1";
      progressBar1.Size = new System.Drawing.Size(894, 19);
      progressBar1.TabIndex = 10;
      progressBar1.Visible = false;
      // 
      // formMain
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      AutoSize = true;
      ClientSize = new System.Drawing.Size(894, 523);
      Controls.Add(splitContainer1);
      Controls.Add(panel1);
      Controls.Add(richTextBoxLog);
      Controls.Add(progressBar1);
      Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
      Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
      Margin = new System.Windows.Forms.Padding(4);
      MinimumSize = new System.Drawing.Size(470, 400);
      Name = "formMain";
      StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      Text = "Dinky Explorer";
      FormClosing += formMain_FormClosing;
      DragDrop += formMain_DragDrop;
      DragEnter += objectListView1_DragEnter;
      panel1.ResumeLayout(false);
      panel1.PerformLayout();
      splitContainer1.Panel1.ResumeLayout(false);
      splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
      splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)objectListView1).EndInit();
      panelAudio.ResumeLayout(false);
      panelAudio.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)trackBarSound).EndInit();
      panelBlank.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
      panelProgress.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)pictureBoxProgress).EndInit();
      panelImage.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).EndInit();
      panelText.ResumeLayout(false);
      panelText.PerformLayout();
      contextMenuSaveAll.ResumeLayout(false);
      contextMenuSaveFile.ResumeLayout(false);
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ContextMenuStrip contextMenuView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn columnFilename;
        private BrightIdeasSoftware.OLVColumn columnFileextension;
        private BrightIdeasSoftware.OLVColumn columnOffset;
        private BrightIdeasSoftware.OLVColumn columnSize;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnSaveAllFiles;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.ImageList imageList1;
        private CueTextBox cueTextBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelBlank;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panelAudio;
        private System.Windows.Forms.Button btnSoundPlay;
        private System.Windows.Forms.Panel panelText;
        private System.Windows.Forms.TextBox textBoxPreview;
        private CustomProgressBar progressBar1;
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Panel panelProgress;
        private System.Windows.Forms.PictureBox pictureBoxProgress;
        private System.Windows.Forms.Button btnSoundPause;
        private System.Windows.Forms.TrackBar trackBarSound;
        private System.Windows.Forms.Button btnSoundStop;
        private System.Windows.Forms.Label labelSoundProgress;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuSaveAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripSaveAllRaw;
        private System.Windows.Forms.ToolStripMenuItem toolStripSaveAllVisible;
        private System.Windows.Forms.ToolStripMenuItem toolStripSaveAllText;
        private System.Windows.Forms.ToolStripMenuItem toolStripSaveAllImages;
        private System.Windows.Forms.ToolStripMenuItem toolStripSaveAllAudio;
        private System.Windows.Forms.ContextMenuStrip contextMenuSaveFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripSaveFileRaw;
        private System.Windows.Forms.ToolStripMenuItem toolStripSaveFileAsText;
        private System.Windows.Forms.ToolStripMenuItem toolStripSaveFileAsImage;
        private System.Windows.Forms.ToolStripMenuItem toolStripSaveFileAsAudio;
        private System.Windows.Forms.ToolStripMenuItem toolStripSaveAllBnut;
        private System.Windows.Forms.Integration.ElementHost bankAudioListHost;
        private System.Windows.Forms.Integration.ElementHost DinkOptionsHost;
    }
}

