using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HBS.ITAG.Models;

namespace HBS.ITAG.Admin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string server_url = "https://hbs-itag.azurewebsites.net";
            string local_url = "http://localhost:8080";

            client = new Client(local_url);
        }

        public Client client;

        private void btnLoadEvents_Click(object sender, EventArgs e)
        {
            client.GetEvents(GetEventsComplete);
        }

        private void GetEventsComplete(string message)
        {
            txtDebug.Text = message;
            lbxEvents.Items.Clear();
            for (int i = 0; i < client.Events.Count; i++)
            {
                lbxEvents.Items.Add(client.Events[i].Name);
            }
            btnLoadTracks.Enabled = true;
        }

        private void GetTracksComplete(string message)
        {
            txtDebug.Text = message;
            lbxTracks.Items.Clear();
            for (int i = 0; i < client.Tracks.Count; i++)
            {
                lbxTracks.Items.Add(client.Tracks[i].Name);
                cbEventsTracks.Items.Add(client.Tracks[i].Name);
            }
            btnLoadLocations.Enabled = true;
        }

        private void GetLocationsComplete(string message)
        {
            txtDebug.Text = message;
            lbxLocations.Items.Clear();
            for (int i = 0; i < client.Locations.Count; i++)
            {
                lbxLocations.Items.Add(client.Locations[i].Name);
                cbEventsLocation.Items.Add(client.Locations[i].Name);
            }
            lbxEvents.Enabled = true;
        }

        private void btnLoadLocations_Click(object sender, EventArgs e)
        {
            client.GetLocations(GetLocationsComplete);
        }

        private void btnLoadTracks_Click(object sender, EventArgs e)
        {
            client.GetTracks(GetTracksComplete);
        }

        private void lbxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbxEvents.SelectedIndex;
            Event tempEvent = client.Events[index];
            lblEventsEventId.Text = tempEvent.Id.ToString();
            dtEventsDate.Value = tempEvent.StartTime;
            dtEventsEndTime.Value = tempEvent.EndTime;
            dtEventsStartTime.Value = tempEvent.StartTime;
            txtEventsName.Text = tempEvent.Name;
            txtEventsPresenter.Text = tempEvent.Presenter;
            txtEventsSummary.Text = tempEvent.Summary;
            chkEventScheduleOnly.Checked = tempEvent.ScheduleOnly;
            txtEventsEventWebId.Text = tempEvent.EventWebId;

            int trackIndex = GetTrackIndex(tempEvent.TrackId);
            cbEventsTracks.SelectedIndex = trackIndex;
            if (trackIndex != -1)
            {
                Track tempTrack = client.Tracks[trackIndex];
                if (tempTrack != null)
                {
                    lblEventsTrackDate.Text = tempTrack.TrackDate.ToString();
                }
            }
            cbEventsLocation.SelectedIndex = GetLocationIndex(tempEvent.LocationId);
            
        }

        private int GetTrackIndex(string trackId)
        {
            int index = -1;
            for (int i = 0; i < client.Tracks.Count; i++)
            {
                if (client.Tracks[i].Id == trackId)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        private int GetLocationIndex(string locationId)
        {
            int index = -1;
            for (int i = 0; i < client.Locations.Count; i++)
            {
                if (client.Locations[i].Id == locationId)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        private void tabEvents_Click(object sender, EventArgs e)
        {

        }

        private void cbEventsTracks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbEventsTracks.SelectedIndex;
            Track temptrack = client.Tracks[index];
            if (temptrack != null)
            {
                lblEventsTrackDate.Text = temptrack.TrackDate.ToString();
            }
        }

        private void lbxTracks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbxTracks.SelectedIndex;
            Track tempTrack = client.Tracks[index];
            lblTracksTrackId.Text = tempTrack.Id.ToString();
            txtTracksName.Text = tempTrack.Name;
            dtTracksTrackDate.Text = tempTrack.TrackDate.ToString();
        }

        private void lbxLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbxLocations.SelectedIndex;
            Location tempLocation = client.Locations[index];
            lblLocationsLocationId.Text = tempLocation.Id;
            txtLocationsBeaconId.Text = tempLocation.BeaconGuid;
            txtLocationsMajor.Text = tempLocation.Major;
            txtLocationsMinor.Text = tempLocation.Minor;
            txtLocationsName.Text = tempLocation.Name;
            txtLocationsNickName.Text = tempLocation.Nickname;
        }

        private void UpdateEventComplete(string message)
        {
        }

        private void AddEventComplete(string message)
        {
            lbxEvents.Items.Clear();
            for (int i = 0; i < client.Events.Count; i++)
            {
                lbxEvents.Items.Add(client.Events[i].Name);
            }
        }

        private void AddTrackComplete(string message)
        {
        }

        private void UpdateTrackComplete(string message)
        {
        }

        private void DeleteUserComplete(string message)
        {
            User tempUser = client.Users[lbxUsers.SelectedIndex];
            client.Users.Remove(tempUser);
            lbxUsers.Items.Clear();
            for (int i = 0; i < client.Users.Count; i++)
            {
                lbxUsers.Items.Add(client.Users[i].DeviceId);
            }
        }

        private void AddUserComplete(string message)
        {
        }

        private void GetUsersComplete(string message)
        {
            txtDebug.Text = message;
            lbxUsers.Items.Clear();
            for (int i = 0; i < client.Users.Count; i++)
            {
                lbxUsers.Items.Add(client.Users[i].DeviceId);
            }
        }

        private void DeleteEventComplete(string message)
        {

            Event tempEvent = client.Events[lbxEvents.SelectedIndex];
            client.Events.Remove(tempEvent);
            lbxEvents.Items.Clear();
            for (int i = 0; i < client.Events.Count; i++)
            {
                lbxEvents.Items.Add(client.Events[i].Name);
            }
            btnLoadTracks.Enabled = true;
        }

        private void btnLocationsUpdate_Click(object sender, EventArgs e)
        {
          

        }

        private void btnEventsUpdate_Click(object sender, EventArgs e)
        {
            Event tempEvent = client.Events[lbxEvents.SelectedIndex];
            Track tempTrack = client.Tracks[cbEventsTracks.SelectedIndex];
            Location tempLocation = null;
            if (cbEventsLocation.SelectedIndex > -1)
            {
                tempLocation = client.Locations[cbEventsLocation.SelectedIndex];
            }

            string trackId = "-1";
            string locationId = "-1";
            if (tempTrack != null)
            {
                trackId = tempTrack.Id;
            }
            if (tempLocation != null)
            {
                locationId = tempLocation.Id;
                tempEvent.LocationId = locationId;
            }

            
            tempEvent.Name = txtEventsName.Text;
            tempEvent.Presenter = txtEventsPresenter.Text;
            tempEvent.Summary = txtEventsSummary.Text;
            tempEvent.ScheduleOnly = chkEventScheduleOnly.Checked;
            tempEvent.EventWebId = txtEventsEventWebId.Text;

            DateTime baseDate = dtEventsDate.Value;
            DateTime startTime = dtEventsStartTime.Value;
            DateTime endTime = dtEventsEndTime.Value;

            DateTime finalStartTime = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, startTime.Hour, startTime.Minute, startTime.Second);
            DateTime finalEndTime = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, endTime.Hour, endTime.Minute, endTime.Second);

            tempEvent.StartTime = finalStartTime;
            tempEvent.EndTime = finalEndTime;

            client.UpdateEvent(tempEvent, UpdateEventComplete);
        }

        private void cbEventsLocation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEventsAdd_Click(object sender, EventArgs e)
        {
          
            
            Track tempTrack = client.Tracks[cbEventsTracks.SelectedIndex];
            Location tempLocation = null;
            if (cbEventsLocation.SelectedIndex > -1)
            {
                tempLocation = client.Locations[cbEventsLocation.SelectedIndex];
            }

            string trackId = "-1";
            string locationId = "-1";
            if (tempTrack != null)
            {
                trackId = tempTrack.Id;
            }
            if (tempLocation != null)
            {
                locationId = tempLocation.Id;
            }


            string name = txtEventsName.Text;
            string presenter = txtEventsPresenter.Text;
            string summary = txtEventsSummary.Text;
            bool scheduleOnly = chkEventScheduleOnly.Checked;

            string eventWebId = txtEventsEventWebId.Text;

            DateTime baseDate = dtEventsDate.Value;
            DateTime startTime = dtEventsStartTime.Value;
            DateTime endTime = dtEventsEndTime.Value;

            DateTime finalStartTime = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, startTime.Hour, startTime.Minute, startTime.Second);
            DateTime finalEndTime = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, endTime.Hour, endTime.Minute, endTime.Second);

             startTime = finalStartTime;

             endTime = finalEndTime;

            Event tempEvent = new Event(name, "-1", startTime, endTime, presenter, summary, eventWebId, trackId, locationId, scheduleOnly);


            client.Events.Add(tempEvent);
            client.AddEvent(tempEvent, AddEventComplete);
      
    }

        private void btnTracksAdd_Click(object sender, EventArgs e)
        {
            string name = txtTracksName.Text;
            DateTime trackDate = dtTracksTrackDate.Value;
            Track tempTrack = new Track(name, "-1", trackDate, "");
            client.AddTrack(tempTrack, AddTrackComplete);
        }

        private void btnTracksUpdate_Click(object sender, EventArgs e)
        {
            Track tempTrack = client.Tracks[lbxTracks.SelectedIndex];
            tempTrack.Name = txtTracksName.Text;
            tempTrack.TrackDate = dtTracksTrackDate.Value;
            client.UpdateTrack(tempTrack, UpdateTrackComplete);


        }

        private void tabTracks_Click(object sender, EventArgs e)
        {

        }

        private void btnEventsDelete_Click(object sender, EventArgs e)
        {
            Event tempEvent = client.Events[lbxEvents.SelectedIndex];
            client.DeleteEvent(tempEvent,DeleteEventComplete);
        }

        private void btnUsersAdd_Click(object sender, EventArgs e)
        {
            string deviceType = cbUsersDeviceType.SelectedItem.ToString();
            string age = cbUsersAge.SelectedItem.ToString();
            string gender = cbUsersGender.SelectedItem.ToString();
            string state = cbUsersState.SelectedItem.ToString();
            string positionTitle = txtUsersPositionTitle.Text;
            string deviceId = txtUsersDeviceId.Text;
            User tempuser = new User("-1", age, gender, positionTitle, state, deviceType, deviceId);
            lbxUsers.Items.Add(tempuser.DeviceId);
            client.AddUser(tempuser, AddUserComplete);
        }

        private void btnUsersDelete_Click(object sender, EventArgs e)
        {
            User tempUser = client.Users[lbxUsers.SelectedIndex];
            client.DeleteUser(tempUser, DeleteUserComplete);
        }

        private void lbxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            User tempUser = client.Users[lbxUsers.SelectedIndex];
            lblUsersUserId.Text = tempUser.Id;
            txtUsersDeviceId.Text = tempUser.DeviceId;
            txtUsersPositionTitle.Text = tempUser.PositionTitle;
            cbUsersAge.SelectedItem = tempUser.Age;
            cbUsersGender.SelectedItem = tempUser.Gender;
            cbUsersState.SelectedItem = tempUser.State;
            cbUsersDeviceType.SelectedItem = tempUser.DeviceType;
        }

        private void cbUsersState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.GetUsers(GetUsersComplete);
        }
    }
}
