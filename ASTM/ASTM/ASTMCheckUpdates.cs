namespace ASTM
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Xml;

  //  using ASTMConfig;

    using KnightsWarriorAutoupdater;

    public class ASTMCheckUpdates
    {
        #region Methods

        public static void update()
        {
            #region check and download new version program
               bool bHasError = false;
               IAutoUpdater autoUpdater = new AutoUpdater();
               try
               {
               autoUpdater.Update();
               }
               catch (WebException exp)
               {
               ASTMGlobal.Logger.LogError("Can not find the specified resource");
               bHasError = true;
               }
               catch (XmlException exp)
               {
               bHasError = true;
               ASTMGlobal.Logger.LogError("Download the upgrade file error");
               }
               catch (NotSupportedException exp)
               {
               bHasError = true;
               ASTMGlobal.Logger.LogError("Upgrade address configuration error");
               }
               catch (ArgumentException exp)
               {
               bHasError = true;
               ASTMGlobal.Logger.LogError("Download the upgrade file error");
               }
               catch (Exception exp)
               {
               bHasError = true;
               ASTMGlobal.Logger.LogError("An error occurred during the upgrade process");
               }
               finally
               {
               if (bHasError == true)
               {
                   try
                   {
                       autoUpdater.RollBack();
                   }
                   catch (Exception)
                   {
                       //Log the message to your file or database
                   }
               }
               }
               #endregion
        }

        #endregion Methods
    }
}