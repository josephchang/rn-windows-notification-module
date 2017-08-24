﻿using ReactNative.Bridge;
using System.Text;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace ReactNativeNotification
{
    public class TileNotificationModule : ReactContextNativeModuleBase
    {
        public TileNotificationModule (ReactContext reactContext)
            : base(reactContext) 
        {
        }

        public override string Name
        {
            get
            {
                return "TileNotification";
            }
        }

        [ReactMethod]
        public void showTileNotification(string notificationXml)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(notificationXml);

            TileNotification notification = new TileNotification(xdoc);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
        }

        [ReactMethod]
        public void clearTileNotification()
        {
            TileUpdateManager.CreateTileUpdaterForApplication().Clear();
        }
    }
}
