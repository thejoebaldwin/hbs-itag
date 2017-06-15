namespace HBS.ITAG.Admin
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEvents = new System.Windows.Forms.TabPage();
            this.txtEventsEventWebId = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.chkEventScheduleOnly = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dtEventsEndTime = new System.Windows.Forms.DateTimePicker();
            this.lbxEvents = new System.Windows.Forms.ListBox();
            this.dtEventsDate = new System.Windows.Forms.DateTimePicker();
            this.dtEventsStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblEventsTrackDate = new System.Windows.Forms.Label();
            this.txtEventsSummary = new System.Windows.Forms.TextBox();
            this.txtEventsPresenter = new System.Windows.Forms.TextBox();
            this.txtEventsName = new System.Windows.Forms.TextBox();
            this.lblEventsEventId = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbEventsTracks = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbEventsLocation = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnEventsDelete = new System.Windows.Forms.Button();
            this.btnEventsUpdate = new System.Windows.Forms.Button();
            this.btnEventsAdd = new System.Windows.Forms.Button();
            this.tabLocations = new System.Windows.Forms.TabPage();
            this.lbxLocations = new System.Windows.Forms.ListBox();
            this.txtLocationsNickName = new System.Windows.Forms.TextBox();
            this.txtLocationsName = new System.Windows.Forms.TextBox();
            this.txtLocationsMajor = new System.Windows.Forms.TextBox();
            this.txtLocationsMinor = new System.Windows.Forms.TextBox();
            this.txtLocationsBeaconId = new System.Windows.Forms.TextBox();
            this.lblLocationsLocationId = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLocationsDelete = new System.Windows.Forms.Button();
            this.btnLocationsUpdate = new System.Windows.Forms.Button();
            this.btnLocationsAdd = new System.Windows.Forms.Button();
            this.tabTracks = new System.Windows.Forms.TabPage();
            this.lbxTracks = new System.Windows.Forms.ListBox();
            this.txtTracksName = new System.Windows.Forms.TextBox();
            this.lblTracksTrackId = new System.Windows.Forms.Label();
            this.dtTracksTrackDate = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.btnTracksDelete = new System.Windows.Forms.Button();
            this.btnTracksUpdate = new System.Windows.Forms.Button();
            this.btnTracksAdd = new System.Windows.Forms.Button();
            this.tabDebug = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.txtDebugRequest = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.btnLoadLocations = new System.Windows.Forms.Button();
            this.btnLoadTracks = new System.Windows.Forms.Button();
            this.btnLoadEvents = new System.Windows.Forms.Button();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.lbxUsers = new System.Windows.Forms.ListBox();
            this.txtUsersPositionTitle = new System.Windows.Forms.TextBox();
            this.lblUsersUserId = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.btnUsersDelete = new System.Windows.Forms.Button();
            this.btnUsersAdd = new System.Windows.Forms.Button();
            this.label99 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtUsersDeviceId = new System.Windows.Forms.TextBox();
            this.cbUsersAge = new System.Windows.Forms.ComboBox();
            this.cbUsersGender = new System.Windows.Forms.ComboBox();
            this.cbUsersState = new System.Windows.Forms.ComboBox();
            this.cbUsersDeviceType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabEvents.SuspendLayout();
            this.tabLocations.SuspendLayout();
            this.tabTracks.SuspendLayout();
            this.tabDebug.SuspendLayout();
            this.tabUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabEvents);
            this.tabControl1.Controls.Add(this.tabLocations);
            this.tabControl1.Controls.Add(this.tabTracks);
            this.tabControl1.Controls.Add(this.tabDebug);
            this.tabControl1.Controls.Add(this.tabUsers);
            this.tabControl1.Location = new System.Drawing.Point(29, 115);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1770, 916);
            this.tabControl1.TabIndex = 0;
            // 
            // tabEvents
            // 
            this.tabEvents.Controls.Add(this.txtEventsEventWebId);
            this.tabEvents.Controls.Add(this.label20);
            this.tabEvents.Controls.Add(this.chkEventScheduleOnly);
            this.tabEvents.Controls.Add(this.label19);
            this.tabEvents.Controls.Add(this.dtEventsEndTime);
            this.tabEvents.Controls.Add(this.lbxEvents);
            this.tabEvents.Controls.Add(this.dtEventsDate);
            this.tabEvents.Controls.Add(this.dtEventsStartTime);
            this.tabEvents.Controls.Add(this.lblEventsTrackDate);
            this.tabEvents.Controls.Add(this.txtEventsSummary);
            this.tabEvents.Controls.Add(this.txtEventsPresenter);
            this.tabEvents.Controls.Add(this.txtEventsName);
            this.tabEvents.Controls.Add(this.lblEventsEventId);
            this.tabEvents.Controls.Add(this.label15);
            this.tabEvents.Controls.Add(this.cbEventsTracks);
            this.tabEvents.Controls.Add(this.label14);
            this.tabEvents.Controls.Add(this.cbEventsLocation);
            this.tabEvents.Controls.Add(this.label13);
            this.tabEvents.Controls.Add(this.label7);
            this.tabEvents.Controls.Add(this.label8);
            this.tabEvents.Controls.Add(this.label9);
            this.tabEvents.Controls.Add(this.label10);
            this.tabEvents.Controls.Add(this.label11);
            this.tabEvents.Controls.Add(this.label12);
            this.tabEvents.Controls.Add(this.btnEventsDelete);
            this.tabEvents.Controls.Add(this.btnEventsUpdate);
            this.tabEvents.Controls.Add(this.btnEventsAdd);
            this.tabEvents.Location = new System.Drawing.Point(8, 39);
            this.tabEvents.Margin = new System.Windows.Forms.Padding(4);
            this.tabEvents.Name = "tabEvents";
            this.tabEvents.Padding = new System.Windows.Forms.Padding(4);
            this.tabEvents.Size = new System.Drawing.Size(1754, 869);
            this.tabEvents.TabIndex = 0;
            this.tabEvents.Text = "Events";
            this.tabEvents.UseVisualStyleBackColor = true;
            this.tabEvents.Click += new System.EventHandler(this.tabEvents_Click);
            // 
            // txtEventsEventWebId
            // 
            this.txtEventsEventWebId.Location = new System.Drawing.Point(632, 592);
            this.txtEventsEventWebId.Margin = new System.Windows.Forms.Padding(4);
            this.txtEventsEventWebId.Name = "txtEventsEventWebId";
            this.txtEventsEventWebId.Size = new System.Drawing.Size(576, 31);
            this.txtEventsEventWebId.TabIndex = 37;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(476, 595);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(128, 25);
            this.label20.TabIndex = 36;
            this.label20.Text = "EventWebId";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkEventScheduleOnly
            // 
            this.chkEventScheduleOnly.AutoSize = true;
            this.chkEventScheduleOnly.Location = new System.Drawing.Point(632, 657);
            this.chkEventScheduleOnly.Margin = new System.Windows.Forms.Padding(6);
            this.chkEventScheduleOnly.Name = "chkEventScheduleOnly";
            this.chkEventScheduleOnly.Size = new System.Drawing.Size(28, 27);
            this.chkEventScheduleOnly.TabIndex = 35;
            this.chkEventScheduleOnly.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(458, 658);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(146, 25);
            this.label19.TabIndex = 34;
            this.label19.Text = "ScheduleOnly";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtEventsEndTime
            // 
            this.dtEventsEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtEventsEndTime.Location = new System.Drawing.Point(632, 460);
            this.dtEventsEndTime.Margin = new System.Windows.Forms.Padding(4);
            this.dtEventsEndTime.Name = "dtEventsEndTime";
            this.dtEventsEndTime.Size = new System.Drawing.Size(276, 31);
            this.dtEventsEndTime.TabIndex = 33;
            // 
            // lbxEvents
            // 
            this.lbxEvents.Enabled = false;
            this.lbxEvents.FormattingEnabled = true;
            this.lbxEvents.ItemHeight = 25;
            this.lbxEvents.Location = new System.Drawing.Point(16, 50);
            this.lbxEvents.Margin = new System.Windows.Forms.Padding(4);
            this.lbxEvents.Name = "lbxEvents";
            this.lbxEvents.Size = new System.Drawing.Size(396, 779);
            this.lbxEvents.TabIndex = 31;
            this.lbxEvents.SelectedIndexChanged += new System.EventHandler(this.lbxEvents_SelectedIndexChanged);
            // 
            // dtEventsDate
            // 
            this.dtEventsDate.Location = new System.Drawing.Point(632, 362);
            this.dtEventsDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtEventsDate.Name = "dtEventsDate";
            this.dtEventsDate.Size = new System.Drawing.Size(496, 31);
            this.dtEventsDate.TabIndex = 30;
            // 
            // dtEventsStartTime
            // 
            this.dtEventsStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtEventsStartTime.Location = new System.Drawing.Point(632, 410);
            this.dtEventsStartTime.Margin = new System.Windows.Forms.Padding(4);
            this.dtEventsStartTime.Name = "dtEventsStartTime";
            this.dtEventsStartTime.Size = new System.Drawing.Size(276, 31);
            this.dtEventsStartTime.TabIndex = 29;
            // 
            // lblEventsTrackDate
            // 
            this.lblEventsTrackDate.AutoSize = true;
            this.lblEventsTrackDate.Location = new System.Drawing.Point(747, 553);
            this.lblEventsTrackDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEventsTrackDate.Name = "lblEventsTrackDate";
            this.lblEventsTrackDate.Size = new System.Drawing.Size(128, 25);
            this.lblEventsTrackDate.TabIndex = 28;
            this.lblEventsTrackDate.Text = "<trackDate>";
            // 
            // txtEventsSummary
            // 
            this.txtEventsSummary.Location = new System.Drawing.Point(632, 702);
            this.txtEventsSummary.Margin = new System.Windows.Forms.Padding(4);
            this.txtEventsSummary.Multiline = true;
            this.txtEventsSummary.Name = "txtEventsSummary";
            this.txtEventsSummary.Size = new System.Drawing.Size(1080, 133);
            this.txtEventsSummary.TabIndex = 27;
            // 
            // txtEventsPresenter
            // 
            this.txtEventsPresenter.Location = new System.Drawing.Point(632, 227);
            this.txtEventsPresenter.Margin = new System.Windows.Forms.Padding(4);
            this.txtEventsPresenter.Name = "txtEventsPresenter";
            this.txtEventsPresenter.Size = new System.Drawing.Size(576, 31);
            this.txtEventsPresenter.TabIndex = 26;
            // 
            // txtEventsName
            // 
            this.txtEventsName.Location = new System.Drawing.Point(632, 156);
            this.txtEventsName.Margin = new System.Windows.Forms.Padding(4);
            this.txtEventsName.Name = "txtEventsName";
            this.txtEventsName.Size = new System.Drawing.Size(578, 31);
            this.txtEventsName.TabIndex = 25;
            // 
            // lblEventsEventId
            // 
            this.lblEventsEventId.AutoSize = true;
            this.lblEventsEventId.Location = new System.Drawing.Point(632, 90);
            this.lblEventsEventId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEventsEventId.Name = "lblEventsEventId";
            this.lblEventsEventId.Size = new System.Drawing.Size(106, 25);
            this.lblEventsEventId.TabIndex = 24;
            this.lblEventsEventId.Text = "<eventId>";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(632, 553);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 25);
            this.label15.TabIndex = 23;
            this.label15.Text = "TrackDate";
            // 
            // cbEventsTracks
            // 
            this.cbEventsTracks.FormattingEnabled = true;
            this.cbEventsTracks.Location = new System.Drawing.Point(632, 508);
            this.cbEventsTracks.Margin = new System.Windows.Forms.Padding(4);
            this.cbEventsTracks.Name = "cbEventsTracks";
            this.cbEventsTracks.Size = new System.Drawing.Size(578, 33);
            this.cbEventsTracks.TabIndex = 22;
            this.cbEventsTracks.SelectedIndexChanged += new System.EventHandler(this.cbEventsTracks_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(538, 508);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 25);
            this.label14.TabIndex = 21;
            this.label14.Text = "Track";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbEventsLocation
            // 
            this.cbEventsLocation.FormattingEnabled = true;
            this.cbEventsLocation.Location = new System.Drawing.Point(632, 304);
            this.cbEventsLocation.Margin = new System.Windows.Forms.Padding(4);
            this.cbEventsLocation.Name = "cbEventsLocation";
            this.cbEventsLocation.Size = new System.Drawing.Size(584, 33);
            this.cbEventsLocation.TabIndex = 20;
            this.cbEventsLocation.SelectedIndexChanged += new System.EventHandler(this.cbEventsLocation_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(510, 304);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 25);
            this.label13.TabIndex = 19;
            this.label13.Text = "Location";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(507, 460);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 25);
            this.label7.TabIndex = 18;
            this.label7.Text = "EndTime";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(500, 365);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 25);
            this.label8.TabIndex = 17;
            this.label8.Text = "StartTime";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(502, 702);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 25);
            this.label9.TabIndex = 16;
            this.label9.Text = "Summary";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(499, 230);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 25);
            this.label10.TabIndex = 15;
            this.label10.Text = "Presenter";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(536, 159);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 25);
            this.label11.TabIndex = 14;
            this.label11.Text = "Name";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(520, 90);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 25);
            this.label12.TabIndex = 13;
            this.label12.Text = "EventId";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnEventsDelete
            // 
            this.btnEventsDelete.Location = new System.Drawing.Point(1524, 31);
            this.btnEventsDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnEventsDelete.Name = "btnEventsDelete";
            this.btnEventsDelete.Size = new System.Drawing.Size(180, 65);
            this.btnEventsDelete.TabIndex = 3;
            this.btnEventsDelete.Text = "Delete";
            this.btnEventsDelete.UseVisualStyleBackColor = true;
            this.btnEventsDelete.Click += new System.EventHandler(this.btnEventsDelete_Click);
            // 
            // btnEventsUpdate
            // 
            this.btnEventsUpdate.Location = new System.Drawing.Point(1304, 31);
            this.btnEventsUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnEventsUpdate.Name = "btnEventsUpdate";
            this.btnEventsUpdate.Size = new System.Drawing.Size(180, 65);
            this.btnEventsUpdate.TabIndex = 2;
            this.btnEventsUpdate.Text = "Update";
            this.btnEventsUpdate.UseVisualStyleBackColor = true;
            this.btnEventsUpdate.Click += new System.EventHandler(this.btnEventsUpdate_Click);
            // 
            // btnEventsAdd
            // 
            this.btnEventsAdd.Location = new System.Drawing.Point(1084, 31);
            this.btnEventsAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnEventsAdd.Name = "btnEventsAdd";
            this.btnEventsAdd.Size = new System.Drawing.Size(180, 65);
            this.btnEventsAdd.TabIndex = 1;
            this.btnEventsAdd.Text = "Add";
            this.btnEventsAdd.UseVisualStyleBackColor = true;
            this.btnEventsAdd.Click += new System.EventHandler(this.btnEventsAdd_Click);
            // 
            // tabLocations
            // 
            this.tabLocations.Controls.Add(this.lbxLocations);
            this.tabLocations.Controls.Add(this.txtLocationsNickName);
            this.tabLocations.Controls.Add(this.txtLocationsName);
            this.tabLocations.Controls.Add(this.txtLocationsMajor);
            this.tabLocations.Controls.Add(this.txtLocationsMinor);
            this.tabLocations.Controls.Add(this.txtLocationsBeaconId);
            this.tabLocations.Controls.Add(this.lblLocationsLocationId);
            this.tabLocations.Controls.Add(this.label6);
            this.tabLocations.Controls.Add(this.label5);
            this.tabLocations.Controls.Add(this.label4);
            this.tabLocations.Controls.Add(this.label3);
            this.tabLocations.Controls.Add(this.label2);
            this.tabLocations.Controls.Add(this.label1);
            this.tabLocations.Controls.Add(this.btnLocationsDelete);
            this.tabLocations.Controls.Add(this.btnLocationsUpdate);
            this.tabLocations.Controls.Add(this.btnLocationsAdd);
            this.tabLocations.Location = new System.Drawing.Point(8, 39);
            this.tabLocations.Margin = new System.Windows.Forms.Padding(4);
            this.tabLocations.Name = "tabLocations";
            this.tabLocations.Padding = new System.Windows.Forms.Padding(4);
            this.tabLocations.Size = new System.Drawing.Size(1754, 869);
            this.tabLocations.TabIndex = 1;
            this.tabLocations.Text = "Locations";
            this.tabLocations.UseVisualStyleBackColor = true;
            // 
            // lbxLocations
            // 
            this.lbxLocations.FormattingEnabled = true;
            this.lbxLocations.ItemHeight = 25;
            this.lbxLocations.Location = new System.Drawing.Point(8, 65);
            this.lbxLocations.Margin = new System.Windows.Forms.Padding(4);
            this.lbxLocations.Name = "lbxLocations";
            this.lbxLocations.Size = new System.Drawing.Size(468, 554);
            this.lbxLocations.TabIndex = 19;
            this.lbxLocations.SelectedIndexChanged += new System.EventHandler(this.lbxLocations_SelectedIndexChanged);
            // 
            // txtLocationsNickName
            // 
            this.txtLocationsNickName.Location = new System.Drawing.Point(711, 458);
            this.txtLocationsNickName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLocationsNickName.Name = "txtLocationsNickName";
            this.txtLocationsNickName.Size = new System.Drawing.Size(364, 31);
            this.txtLocationsNickName.TabIndex = 18;
            // 
            // txtLocationsName
            // 
            this.txtLocationsName.Location = new System.Drawing.Point(711, 392);
            this.txtLocationsName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLocationsName.Name = "txtLocationsName";
            this.txtLocationsName.Size = new System.Drawing.Size(364, 31);
            this.txtLocationsName.TabIndex = 17;
            // 
            // txtLocationsMajor
            // 
            this.txtLocationsMajor.Location = new System.Drawing.Point(711, 327);
            this.txtLocationsMajor.Margin = new System.Windows.Forms.Padding(4);
            this.txtLocationsMajor.Name = "txtLocationsMajor";
            this.txtLocationsMajor.Size = new System.Drawing.Size(376, 31);
            this.txtLocationsMajor.TabIndex = 16;
            // 
            // txtLocationsMinor
            // 
            this.txtLocationsMinor.Location = new System.Drawing.Point(711, 263);
            this.txtLocationsMinor.Margin = new System.Windows.Forms.Padding(4);
            this.txtLocationsMinor.Name = "txtLocationsMinor";
            this.txtLocationsMinor.Size = new System.Drawing.Size(376, 31);
            this.txtLocationsMinor.TabIndex = 15;
            // 
            // txtLocationsBeaconId
            // 
            this.txtLocationsBeaconId.Location = new System.Drawing.Point(711, 196);
            this.txtLocationsBeaconId.Margin = new System.Windows.Forms.Padding(4);
            this.txtLocationsBeaconId.Name = "txtLocationsBeaconId";
            this.txtLocationsBeaconId.Size = new System.Drawing.Size(376, 31);
            this.txtLocationsBeaconId.TabIndex = 14;
            // 
            // lblLocationsLocationId
            // 
            this.lblLocationsLocationId.AutoSize = true;
            this.lblLocationsLocationId.Location = new System.Drawing.Point(711, 138);
            this.lblLocationsLocationId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationsLocationId.Name = "lblLocationsLocationId";
            this.lblLocationsLocationId.Size = new System.Drawing.Size(128, 25);
            this.lblLocationsLocationId.TabIndex = 13;
            this.lblLocationsLocationId.Text = "<locationId>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(556, 460);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Nickname";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(595, 394);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Name";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(597, 331);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Major";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(597, 267);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Minor";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(561, 204);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "BeaconId";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(552, 138);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "LocationId";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnLocationsDelete
            // 
            this.btnLocationsDelete.Location = new System.Drawing.Point(1296, 43);
            this.btnLocationsDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnLocationsDelete.Name = "btnLocationsDelete";
            this.btnLocationsDelete.Size = new System.Drawing.Size(180, 65);
            this.btnLocationsDelete.TabIndex = 6;
            this.btnLocationsDelete.Text = "Delete";
            this.btnLocationsDelete.UseVisualStyleBackColor = true;
            // 
            // btnLocationsUpdate
            // 
            this.btnLocationsUpdate.Location = new System.Drawing.Point(1094, 43);
            this.btnLocationsUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnLocationsUpdate.Name = "btnLocationsUpdate";
            this.btnLocationsUpdate.Size = new System.Drawing.Size(180, 65);
            this.btnLocationsUpdate.TabIndex = 5;
            this.btnLocationsUpdate.Text = "Update";
            this.btnLocationsUpdate.UseVisualStyleBackColor = true;
            this.btnLocationsUpdate.Click += new System.EventHandler(this.btnLocationsUpdate_Click);
            // 
            // btnLocationsAdd
            // 
            this.btnLocationsAdd.Location = new System.Drawing.Point(895, 43);
            this.btnLocationsAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnLocationsAdd.Name = "btnLocationsAdd";
            this.btnLocationsAdd.Size = new System.Drawing.Size(180, 65);
            this.btnLocationsAdd.TabIndex = 4;
            this.btnLocationsAdd.Text = "Add";
            this.btnLocationsAdd.UseVisualStyleBackColor = true;
            // 
            // tabTracks
            // 
            this.tabTracks.Controls.Add(this.lbxTracks);
            this.tabTracks.Controls.Add(this.txtTracksName);
            this.tabTracks.Controls.Add(this.lblTracksTrackId);
            this.tabTracks.Controls.Add(this.dtTracksTrackDate);
            this.tabTracks.Controls.Add(this.label16);
            this.tabTracks.Controls.Add(this.label23);
            this.tabTracks.Controls.Add(this.label24);
            this.tabTracks.Controls.Add(this.btnTracksDelete);
            this.tabTracks.Controls.Add(this.btnTracksUpdate);
            this.tabTracks.Controls.Add(this.btnTracksAdd);
            this.tabTracks.Location = new System.Drawing.Point(8, 39);
            this.tabTracks.Margin = new System.Windows.Forms.Padding(4);
            this.tabTracks.Name = "tabTracks";
            this.tabTracks.Size = new System.Drawing.Size(1754, 869);
            this.tabTracks.TabIndex = 2;
            this.tabTracks.Text = "Tracks";
            this.tabTracks.UseVisualStyleBackColor = true;
            this.tabTracks.Click += new System.EventHandler(this.tabTracks_Click);
            // 
            // lbxTracks
            // 
            this.lbxTracks.FormattingEnabled = true;
            this.lbxTracks.ItemHeight = 25;
            this.lbxTracks.Location = new System.Drawing.Point(4, 52);
            this.lbxTracks.Margin = new System.Windows.Forms.Padding(4);
            this.lbxTracks.Name = "lbxTracks";
            this.lbxTracks.Size = new System.Drawing.Size(452, 604);
            this.lbxTracks.TabIndex = 38;
            this.lbxTracks.SelectedIndexChanged += new System.EventHandler(this.lbxTracks_SelectedIndexChanged);
            // 
            // txtTracksName
            // 
            this.txtTracksName.Location = new System.Drawing.Point(638, 271);
            this.txtTracksName.Margin = new System.Windows.Forms.Padding(4);
            this.txtTracksName.Name = "txtTracksName";
            this.txtTracksName.Size = new System.Drawing.Size(550, 31);
            this.txtTracksName.TabIndex = 37;
            // 
            // lblTracksTrackId
            // 
            this.lblTracksTrackId.AutoSize = true;
            this.lblTracksTrackId.Location = new System.Drawing.Point(638, 206);
            this.lblTracksTrackId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTracksTrackId.Name = "lblTracksTrackId";
            this.lblTracksTrackId.Size = new System.Drawing.Size(107, 25);
            this.lblTracksTrackId.TabIndex = 36;
            this.lblTracksTrackId.Text = "<TrackId>";
            // 
            // dtTracksTrackDate
            // 
            this.dtTracksTrackDate.Location = new System.Drawing.Point(638, 348);
            this.dtTracksTrackDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtTracksTrackDate.Name = "dtTracksTrackDate";
            this.dtTracksTrackDate.Size = new System.Drawing.Size(550, 31);
            this.dtTracksTrackDate.TabIndex = 35;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(491, 348);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 25);
            this.label16.TabIndex = 34;
            this.label16.Text = "TrackDate";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(534, 271);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(68, 25);
            this.label23.TabIndex = 25;
            this.label23.Text = "Name";
            this.label23.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(519, 206);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(83, 25);
            this.label24.TabIndex = 24;
            this.label24.Text = "TrackId";
            this.label24.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnTracksDelete
            // 
            this.btnTracksDelete.Location = new System.Drawing.Point(1048, 52);
            this.btnTracksDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnTracksDelete.Name = "btnTracksDelete";
            this.btnTracksDelete.Size = new System.Drawing.Size(180, 65);
            this.btnTracksDelete.TabIndex = 6;
            this.btnTracksDelete.Text = "Delete";
            this.btnTracksDelete.UseVisualStyleBackColor = true;
            // 
            // btnTracksUpdate
            // 
            this.btnTracksUpdate.Location = new System.Drawing.Point(844, 52);
            this.btnTracksUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnTracksUpdate.Name = "btnTracksUpdate";
            this.btnTracksUpdate.Size = new System.Drawing.Size(180, 65);
            this.btnTracksUpdate.TabIndex = 5;
            this.btnTracksUpdate.Text = "Update";
            this.btnTracksUpdate.UseVisualStyleBackColor = true;
            this.btnTracksUpdate.Click += new System.EventHandler(this.btnTracksUpdate_Click);
            // 
            // btnTracksAdd
            // 
            this.btnTracksAdd.Location = new System.Drawing.Point(641, 52);
            this.btnTracksAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnTracksAdd.Name = "btnTracksAdd";
            this.btnTracksAdd.Size = new System.Drawing.Size(180, 65);
            this.btnTracksAdd.TabIndex = 4;
            this.btnTracksAdd.Text = "Add";
            this.btnTracksAdd.UseVisualStyleBackColor = true;
            this.btnTracksAdd.Click += new System.EventHandler(this.btnTracksAdd_Click);
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.label18);
            this.tabDebug.Controls.Add(this.txtDebugRequest);
            this.tabDebug.Controls.Add(this.label17);
            this.tabDebug.Controls.Add(this.txtDebug);
            this.tabDebug.Location = new System.Drawing.Point(8, 39);
            this.tabDebug.Margin = new System.Windows.Forms.Padding(4);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Size = new System.Drawing.Size(1754, 869);
            this.tabDebug.TabIndex = 3;
            this.tabDebug.Text = "Debug";
            this.tabDebug.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(36, 552);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 25);
            this.label18.TabIndex = 3;
            this.label18.Text = "Request";
            // 
            // txtDebugRequest
            // 
            this.txtDebugRequest.Location = new System.Drawing.Point(72, 602);
            this.txtDebugRequest.Margin = new System.Windows.Forms.Padding(4);
            this.txtDebugRequest.Multiline = true;
            this.txtDebugRequest.Name = "txtDebugRequest";
            this.txtDebugRequest.Size = new System.Drawing.Size(1108, 460);
            this.txtDebugRequest.TabIndex = 2;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(68, 17);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(109, 25);
            this.label17.TabIndex = 1;
            this.label17.Text = "Response";
            // 
            // txtDebug
            // 
            this.txtDebug.Location = new System.Drawing.Point(104, 67);
            this.txtDebug.Margin = new System.Windows.Forms.Padding(4);
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.Size = new System.Drawing.Size(1108, 460);
            this.txtDebug.TabIndex = 0;
            // 
            // btnLoadLocations
            // 
            this.btnLoadLocations.Enabled = false;
            this.btnLoadLocations.Location = new System.Drawing.Point(758, 21);
            this.btnLoadLocations.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadLocations.Name = "btnLoadLocations";
            this.btnLoadLocations.Size = new System.Drawing.Size(180, 65);
            this.btnLoadLocations.TabIndex = 20;
            this.btnLoadLocations.Text = "Load Locations";
            this.btnLoadLocations.UseVisualStyleBackColor = true;
            this.btnLoadLocations.Click += new System.EventHandler(this.btnLoadLocations_Click);
            // 
            // btnLoadTracks
            // 
            this.btnLoadTracks.Enabled = false;
            this.btnLoadTracks.Location = new System.Drawing.Point(555, 21);
            this.btnLoadTracks.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadTracks.Name = "btnLoadTracks";
            this.btnLoadTracks.Size = new System.Drawing.Size(180, 65);
            this.btnLoadTracks.TabIndex = 21;
            this.btnLoadTracks.Text = "Load Tracks";
            this.btnLoadTracks.UseVisualStyleBackColor = true;
            this.btnLoadTracks.Click += new System.EventHandler(this.btnLoadTracks_Click);
            // 
            // btnLoadEvents
            // 
            this.btnLoadEvents.Location = new System.Drawing.Point(348, 21);
            this.btnLoadEvents.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadEvents.Name = "btnLoadEvents";
            this.btnLoadEvents.Size = new System.Drawing.Size(180, 65);
            this.btnLoadEvents.TabIndex = 22;
            this.btnLoadEvents.Text = "Load Events";
            this.btnLoadEvents.UseVisualStyleBackColor = true;
            this.btnLoadEvents.Click += new System.EventHandler(this.btnLoadEvents_Click);
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.cbUsersDeviceType);
            this.tabUsers.Controls.Add(this.cbUsersState);
            this.tabUsers.Controls.Add(this.cbUsersGender);
            this.tabUsers.Controls.Add(this.cbUsersAge);
            this.tabUsers.Controls.Add(this.txtUsersDeviceId);
            this.tabUsers.Controls.Add(this.label28);
            this.tabUsers.Controls.Add(this.label27);
            this.tabUsers.Controls.Add(this.label22);
            this.tabUsers.Controls.Add(this.label21);
            this.tabUsers.Controls.Add(this.label99);
            this.tabUsers.Controls.Add(this.lbxUsers);
            this.tabUsers.Controls.Add(this.txtUsersPositionTitle);
            this.tabUsers.Controls.Add(this.lblUsersUserId);
            this.tabUsers.Controls.Add(this.label25);
            this.tabUsers.Controls.Add(this.label26);
            this.tabUsers.Controls.Add(this.btnUsersDelete);
            this.tabUsers.Controls.Add(this.btnUsersAdd);
            this.tabUsers.Location = new System.Drawing.Point(8, 39);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Size = new System.Drawing.Size(1754, 869);
            this.tabUsers.TabIndex = 4;
            this.tabUsers.Text = "Users";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // lbxUsers
            // 
            this.lbxUsers.FormattingEnabled = true;
            this.lbxUsers.ItemHeight = 25;
            this.lbxUsers.Location = new System.Drawing.Point(32, 73);
            this.lbxUsers.Margin = new System.Windows.Forms.Padding(4);
            this.lbxUsers.Name = "lbxUsers";
            this.lbxUsers.Size = new System.Drawing.Size(452, 604);
            this.lbxUsers.TabIndex = 48;
            this.lbxUsers.SelectedIndexChanged += new System.EventHandler(this.lbxUsers_SelectedIndexChanged);
            // 
            // txtUsersPositionTitle
            // 
            this.txtUsersPositionTitle.Location = new System.Drawing.Point(671, 475);
            this.txtUsersPositionTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsersPositionTitle.Name = "txtUsersPositionTitle";
            this.txtUsersPositionTitle.Size = new System.Drawing.Size(550, 31);
            this.txtUsersPositionTitle.TabIndex = 47;
            // 
            // lblUsersUserId
            // 
            this.lblUsersUserId.AutoSize = true;
            this.lblUsersUserId.Location = new System.Drawing.Point(666, 227);
            this.lblUsersUserId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsersUserId.Name = "lblUsersUserId";
            this.lblUsersUserId.Size = new System.Drawing.Size(98, 25);
            this.lblUsersUserId.TabIndex = 46;
            this.lblUsersUserId.Text = "<UserId>";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(571, 297);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(50, 25);
            this.label25.TabIndex = 43;
            this.label25.Text = "Age";
            this.label25.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(547, 227);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(74, 25);
            this.label26.TabIndex = 42;
            this.label26.Text = "UserId";
            this.label26.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnUsersDelete
            // 
            this.btnUsersDelete.Location = new System.Drawing.Point(904, 73);
            this.btnUsersDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnUsersDelete.Name = "btnUsersDelete";
            this.btnUsersDelete.Size = new System.Drawing.Size(180, 65);
            this.btnUsersDelete.TabIndex = 41;
            this.btnUsersDelete.Text = "Delete";
            this.btnUsersDelete.UseVisualStyleBackColor = true;
            this.btnUsersDelete.Click += new System.EventHandler(this.btnUsersDelete_Click);
            // 
            // btnUsersAdd
            // 
            this.btnUsersAdd.Location = new System.Drawing.Point(669, 73);
            this.btnUsersAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnUsersAdd.Name = "btnUsersAdd";
            this.btnUsersAdd.Size = new System.Drawing.Size(180, 65);
            this.btnUsersAdd.TabIndex = 39;
            this.btnUsersAdd.Text = "Add";
            this.btnUsersAdd.UseVisualStyleBackColor = true;
            this.btnUsersAdd.Click += new System.EventHandler(this.btnUsersAdd_Click);
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(492, 475);
            this.label99.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(136, 25);
            this.label99.TabIndex = 49;
            this.label99.Text = "Position/Title";
            this.label99.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(538, 364);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 25);
            this.label21.TabIndex = 50;
            this.label21.Text = "Gender";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(559, 424);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(62, 25);
            this.label22.TabIndex = 51;
            this.label22.Text = "State";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(495, 544);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(126, 25);
            this.label27.TabIndex = 52;
            this.label27.Text = "DeviceType";
            this.label27.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(526, 608);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(95, 25);
            this.label28.TabIndex = 53;
            this.label28.Text = "DeviceId";
            this.label28.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtUsersDeviceId
            // 
            this.txtUsersDeviceId.Location = new System.Drawing.Point(669, 608);
            this.txtUsersDeviceId.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsersDeviceId.Name = "txtUsersDeviceId";
            this.txtUsersDeviceId.Size = new System.Drawing.Size(550, 31);
            this.txtUsersDeviceId.TabIndex = 54;
            // 
            // cbUsersAge
            // 
            this.cbUsersAge.FormattingEnabled = true;
            this.cbUsersAge.Items.AddRange(new object[] {
            "10-14",
            "15-19",
            "20-24",
            "25-29",
            "30-34",
            "35-39",
            "40-44",
            "45-49",
            "50-54",
            "55-59",
            "60-64",
            "65-69",
            "70-74",
            "75-79",
            "80-84",
            "85-89",
            "90-94",
            "95-100"});
            this.cbUsersAge.Location = new System.Drawing.Point(672, 297);
            this.cbUsersAge.Margin = new System.Windows.Forms.Padding(4);
            this.cbUsersAge.Name = "cbUsersAge";
            this.cbUsersAge.Size = new System.Drawing.Size(584, 33);
            this.cbUsersAge.TabIndex = 55;
            // 
            // cbUsersGender
            // 
            this.cbUsersGender.FormattingEnabled = true;
            this.cbUsersGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other",
            "Prefer Not to Say"});
            this.cbUsersGender.Location = new System.Drawing.Point(669, 364);
            this.cbUsersGender.Margin = new System.Windows.Forms.Padding(4);
            this.cbUsersGender.Name = "cbUsersGender";
            this.cbUsersGender.Size = new System.Drawing.Size(584, 33);
            this.cbUsersGender.TabIndex = 56;
            // 
            // cbUsersState
            // 
            this.cbUsersState.FormattingEnabled = true;
            this.cbUsersState.Items.AddRange(new object[] {
            "AK",
            "AL",
            "AZ",
            "AR",
            "CA",
            "CO",
            "CT",
            "DE",
            "FL",
            "GA",
            "HI",
            "ID",
            "IL",
            "IN",
            "IA",
            "KS",
            "KY",
            "LA",
            "ME",
            "MD",
            "MA",
            "MI",
            "MN",
            "MS",
            "MO",
            "MT",
            "NE",
            "NV",
            "NH",
            "NJ",
            "NM",
            "NY",
            "NC",
            "ND",
            "OH",
            "OK",
            "OR",
            "PA",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VT",
            "VA",
            "WA",
            "WV",
            "WI",
            "WY"});
            this.cbUsersState.Location = new System.Drawing.Point(672, 424);
            this.cbUsersState.Margin = new System.Windows.Forms.Padding(4);
            this.cbUsersState.Name = "cbUsersState";
            this.cbUsersState.Size = new System.Drawing.Size(584, 33);
            this.cbUsersState.TabIndex = 57;
            this.cbUsersState.SelectedIndexChanged += new System.EventHandler(this.cbUsersState_SelectedIndexChanged);
            // 
            // cbUsersDeviceType
            // 
            this.cbUsersDeviceType.FormattingEnabled = true;
            this.cbUsersDeviceType.Items.AddRange(new object[] {
            "Android",
            "iOS"});
            this.cbUsersDeviceType.Location = new System.Drawing.Point(669, 544);
            this.cbUsersDeviceType.Margin = new System.Windows.Forms.Padding(4);
            this.cbUsersDeviceType.Name = "cbUsersDeviceType";
            this.cbUsersDeviceType.Size = new System.Drawing.Size(584, 33);
            this.cbUsersDeviceType.TabIndex = 58;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1010, 21);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 65);
            this.button1.TabIndex = 23;
            this.button1.Text = "Load Users";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1838, 1044);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLoadEvents);
            this.Controls.Add(this.btnLoadTracks);
            this.Controls.Add(this.btnLoadLocations);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "ITAG Admin";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabEvents.ResumeLayout(false);
            this.tabEvents.PerformLayout();
            this.tabLocations.ResumeLayout(false);
            this.tabLocations.PerformLayout();
            this.tabTracks.ResumeLayout(false);
            this.tabTracks.PerformLayout();
            this.tabDebug.ResumeLayout(false);
            this.tabDebug.PerformLayout();
            this.tabUsers.ResumeLayout(false);
            this.tabUsers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEvents;
        private System.Windows.Forms.TabPage tabLocations;
        private System.Windows.Forms.TabPage tabTracks;
        private System.Windows.Forms.DateTimePicker dtEventsStartTime;
        private System.Windows.Forms.Label lblEventsTrackDate;
        private System.Windows.Forms.TextBox txtEventsSummary;
        private System.Windows.Forms.TextBox txtEventsPresenter;
        private System.Windows.Forms.TextBox txtEventsName;
        private System.Windows.Forms.Label lblEventsEventId;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbEventsTracks;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbEventsLocation;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnEventsDelete;
        private System.Windows.Forms.Button btnEventsUpdate;
        private System.Windows.Forms.Button btnEventsAdd;
        private System.Windows.Forms.TextBox txtLocationsNickName;
        private System.Windows.Forms.TextBox txtLocationsName;
        private System.Windows.Forms.TextBox txtLocationsMajor;
        private System.Windows.Forms.TextBox txtLocationsMinor;
        private System.Windows.Forms.TextBox txtLocationsBeaconId;
        private System.Windows.Forms.Label lblLocationsLocationId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLocationsDelete;
        private System.Windows.Forms.Button btnLocationsUpdate;
        private System.Windows.Forms.Button btnLocationsAdd;
        private System.Windows.Forms.TextBox txtTracksName;
        private System.Windows.Forms.Label lblTracksTrackId;
        private System.Windows.Forms.DateTimePicker dtTracksTrackDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnTracksDelete;
        private System.Windows.Forms.Button btnTracksUpdate;
        private System.Windows.Forms.Button btnTracksAdd;
        private System.Windows.Forms.Button btnLoadLocations;
        private System.Windows.Forms.Button btnLoadTracks;
        private System.Windows.Forms.Button btnLoadEvents;
        private System.Windows.Forms.TabPage tabDebug;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.ListBox lbxEvents;
        private System.Windows.Forms.ListBox lbxLocations;
        private System.Windows.Forms.ListBox lbxTracks;
        private System.Windows.Forms.DateTimePicker dtEventsEndTime;
        private System.Windows.Forms.DateTimePicker dtEventsDate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtDebugRequest;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkEventScheduleOnly;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtEventsEventWebId;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.ComboBox cbUsersDeviceType;
        private System.Windows.Forms.ComboBox cbUsersState;
        private System.Windows.Forms.ComboBox cbUsersGender;
        private System.Windows.Forms.ComboBox cbUsersAge;
        private System.Windows.Forms.TextBox txtUsersDeviceId;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.ListBox lbxUsers;
        private System.Windows.Forms.TextBox txtUsersPositionTitle;
        private System.Windows.Forms.Label lblUsersUserId;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnUsersDelete;
        private System.Windows.Forms.Button btnUsersAdd;
        private System.Windows.Forms.Button button1;
    }
}

