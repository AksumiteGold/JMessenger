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

        //This method will get the info from the chat server and send 
        public async void GetInfo(string name, string room)
        {
            ListView msgview = FindViewById<ListView>(Resource.Id.msgview);
            EditText chatmsg = (EditText)FindViewById(Resource.Id.msg);
            var Messages = new List<string>();

            // Connection to the server
            var hubConnection = new HubConnection("http://jabberserver.azurewebsites.net/");

            // This creates a proxy to the 'ChatHub' SignalR Hub 
            var chatHubProxy = hubConnection.CreateHubProxy("ChatHub");

            // Wire up a handler for the 'addChatMessage' for the server
            // to be called on our client
            chatHubProxy.On<string, string>("addChatMessage", (user, message) =>
            {
                this.RunOnUiThread(() =>
                {
                    Messages.Add(user + ": " + Cryptology.Decrypt(message, "abdella"));
                    ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Messages);
                    msgview.Adapter = adapter;
                    //text.Text += string.Format("Received Msg: {0}\r\n", message);
                });
            });

            try
            {
                // Starts the connection to the server
                await hubConnection.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Button btn_send = FindViewById<Button>(Resource.Id.btn_send);

            //This will join the user to the room through the "JoinRoom" method in the server
            await chatHubProxy.Invoke("JoinRoom", new object[] { name, room });

            //This button will send the message through the "SendToSpecificRoom" method in the server 
            btn_send.Click += async delegate
            {
                await chatHubProxy.Invoke("SendToSpecificRoom", new object[] { name, Cryptology.Encrypt(chatmsg.Text, "abdella"), room });
                chatmsg.Text = "";
            };

        }
    }
}