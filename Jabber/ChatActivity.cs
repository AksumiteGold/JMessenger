using System;
using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Widget;
using Microsoft.AspNet.SignalR.Client;

namespace Jabber
{
    [Activity(Label = "Jabber", MainLauncher = false, Icon = "@drawable/icon")]
    public class ChatActivity: Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Chat_Activity);
            GetData getdata = new GetData();
            GetInfo(getdata.getUsername(), "room");
        }

        public async void GetInfo(string name, string room)
        {
            ListView msgview = FindViewById<ListView>(Resource.Id.msgview);
            EditText chatmsg = (EditText)FindViewById(Resource.Id.msg);
            var Messages = new List<string>();

            // Connect to the server
            var hubConnection = new HubConnection("http://jabberserver.azurewebsites.net/");

            // Create a proxy to the 'ChatHub' SignalR Hub 
            var chatHubProxy = hubConnection.CreateHubProxy("ChatHub");

            // Wire up a handler for the 'UpdateChatMessage' for the server
            // to be called on our client
            //chatHubProxy.On<string, string>("broadcastMessage", (user, message) =>
            chatHubProxy.On<string, string>("addChatMessage", (user, message) =>
            {
                this.RunOnUiThread(() =>
                {
                    Messages.Add(user + ": " + message);
                    ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Messages);
                    msgview.Adapter = adapter;
                    //text.Text += string.Format("Received Msg: {0}\r\n", message);
                });
            });

            try
            {
                // Start the connection
                await hubConnection.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Button btn_send = FindViewById<Button>(Resource.Id.btn_send);

            await chatHubProxy.Invoke("JoinRoom", new object[] { name, room });

            btn_send.Click += async delegate
            {
                //await chatHubProxy.Invoke("SendMessage", new object[] { name, chatmsg.Text });
                await chatHubProxy.Invoke("SendToSpecificRoom", new object[] { name, chatmsg.Text, room });
                chatmsg.Text = "";
            };

        }
    }
}