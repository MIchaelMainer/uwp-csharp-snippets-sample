﻿//Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
//See LICENSE in the project root for license information.


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Microsoft_Graph_Snippets_SDK
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //Header strings for the different scope groups.
        public const string ScopeGroupAll = "Applicable to personal or work accounts";
        public const string ScopeGroupWork = "Applicable to work accounts only";
        public const string ScopeGroupWorkAdmin = "Applicable to work accounts with admin rights";

        public List<StoryDefinition> StoryCollection { get; private set; }
        public MainPage()
        {
            this.InitializeComponent();
            CreateStoryList();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Developer code - if you haven't registered the app yet, we warn you. 
            if (!App.Current.Resources.ContainsKey("ida:ClientID"))
            {
                Debug.WriteLine("Oops - App not registered. To run this sample, you must register it with the App Registration Portal. See Readme for more info.");

            }
        }
        private void CreateStoryList()
        {
            StoryCollection = new List<StoryDefinition>();

            // Stories applicable to both work or school and personal accounts
            // NOTE: All of these snippets require permissions available whether you sign into the sample 
            // with a or work or school (commercial) or personal (consumer) account

            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Get Me",  ScopeGroup= ScopeGroupAll, RunStoryAsync = UserStories.TryGetMeAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Read Users", ScopeGroup = ScopeGroupAll, RunStoryAsync = UserStories.TryGetUsersAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Get Drive", ScopeGroup = ScopeGroupAll, RunStoryAsync = UserStories.TryGetCurrentUserDriveAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Get Events", ScopeGroup = ScopeGroupAll, RunStoryAsync = UserStories.TryGetEventsAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Create Event", ScopeGroup = ScopeGroupAll, RunStoryAsync = UserStories.TryCreateEventAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Update Event", ScopeGroup = ScopeGroupAll, RunStoryAsync = UserStories.TryUpdateEventAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Delete Event", ScopeGroup = ScopeGroupAll, RunStoryAsync = UserStories.TryDeleteEventAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Get Messages", ScopeGroup = ScopeGroupAll, RunStoryAsync = UserStories.TryGetMessages });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Send Message", ScopeGroup = ScopeGroupAll, RunStoryAsync = UserStories.TrySendMailAsync });

            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Get User Files", ScopeGroup = ScopeGroupAll, RunStoryAsync = UserStories.TryGetCurrentUserFilesAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Create Text File", ScopeGroup = ScopeGroupAll, RunStoryAsync = UserStories.TryCreateFileAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Download File", ScopeGroup = ScopeGroupAll, RunStoryAsync = UserStories.TryDownloadFileAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Update File", ScopeGroup = ScopeGroupAll, RunStoryAsync = UserStories.TryUpdateFileAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Rename File", ScopeGroup = ScopeGroupAll, RunStoryAsync = UserStories.TryRenameFileAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Delete File", ScopeGroup = ScopeGroupAll, RunStoryAsync = UserStories.TryDeleteFileAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Create Folder", ScopeGroup = ScopeGroupAll, RunStoryAsync = UserStories.TryCreateFolderAsync });


            // Stories applicable only to work or school accounts
            // NOTE: All of these snippets will fail for lack of permissions if you sign into the sample with a personal (consumer) account

            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Get Manager", ScopeGroup = ScopeGroupWork, RunStoryAsync = UserStories.TryGetCurrentUserManagerAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Get Directs", ScopeGroup = ScopeGroupWork, RunStoryAsync = UserStories.TryGetDirectReportsAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Get Photo", ScopeGroup = ScopeGroupWork, RunStoryAsync = UserStories.TryGetCurrentUserPhotoAsync });


            // Stories applicable only to work or school accounts with admin access
            // NOTE: All of these snippets will fail for lack of permissions if you sign into the sample with a non-admin work account
            // or any consumer account. 

            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Create User", ScopeGroup = ScopeGroupWorkAdmin, RunStoryAsync = UserStories.TryCreateUserAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Users", Title = "Get User Groups", ScopeGroup = ScopeGroupWorkAdmin, RunStoryAsync = UserStories.TryGetCurrentUserGroupsAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Groups", Title = "Get All Groups", ScopeGroup = ScopeGroupWorkAdmin, RunStoryAsync = GroupStories.TryGetGroupsAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Groups", Title = "Get a Group", ScopeGroup = ScopeGroupWorkAdmin, RunStoryAsync = GroupStories.TryGetGroupAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Groups", Title = "Get Members", ScopeGroup = ScopeGroupWorkAdmin, RunStoryAsync = GroupStories.TryGetGroupMembersAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Groups", Title = "Get Owners", ScopeGroup = ScopeGroupWorkAdmin, RunStoryAsync = GroupStories.TryGetGroupOwnersAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Groups", Title = "Create Group", ScopeGroup = ScopeGroupWorkAdmin, RunStoryAsync = GroupStories.TryCreateGroupAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Groups", Title = "Update Group", ScopeGroup = ScopeGroupWorkAdmin, RunStoryAsync = GroupStories.TryUpdateGroupAsync });
            StoryCollection.Add(new StoryDefinition() { GroupName = "Groups", Title = "Delete Group", ScopeGroup = ScopeGroupWorkAdmin, RunStoryAsync = GroupStories.TryDeleteGroupAsync });


            var result = from story in StoryCollection group story by story.ScopeGroup into api orderby api.Key select api;
            StoriesByApi.Source = result;
        }


        private async void RunSelectedStories_Click(object sender, RoutedEventArgs e)
        {

            await runSelectedAsync();
        }

        private async Task runSelectedAsync()
        {
            ResetStories();
            Stopwatch sw = new Stopwatch();

            foreach (var story in StoryGrid.SelectedItems)
            {
                StoryDefinition currentStory = story as StoryDefinition;
                currentStory.IsRunning = true;
                sw.Restart();
                bool result = false;
                try
                {
                    result = await currentStory.RunStoryAsync();
                    Debug.WriteLine(String.Format("{0}.{1} {2}", currentStory.GroupName, currentStory.Title, (result) ? "passed" : "failed"));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("{0}.{1} failed. Exception: {2}", currentStory.GroupName, currentStory.Title, ex.Message);
                    result = false;

                }
                currentStory.Result = result;
                sw.Stop();
                currentStory.DurationMS = sw.ElapsedMilliseconds;
                currentStory.IsRunning = false;


            }

            // To shut down this app when the Stories complete, uncomment the following line. 
            // Application.Current.Exit();
        }

        private void ResetStories()
        {
            foreach (var story in StoryCollection)
            {
                story.Result = null;
                story.DurationMS = null;
            }
        }

        private void ClearSelection_Click(object sender, RoutedEventArgs e)
        {
            StoryGrid.SelectedItems.Clear();
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            AuthenticationHelper.SignOut();
            StoryGrid.SelectedItems.Clear();
        }

    }
}
