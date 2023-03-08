// ***********************************************************************
// Assembly         : SigmaNESTPlugin
// Author           : Anthony Roberson
// Created          : 10-09-2015
//
// Last Modified By : Anthony Roberson
// Last Modified On : 10-09-2015
// ***********************************************************************
// <copyright file="SigmaNESTPlugin.cs" company="SigmaTEK Systems">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using DllExport;
using INI;
using SigmaNEST;
using SNPlugin;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

/// <summary>
/// The ExcelImport_PartsLibrary namespace.
/// </summary>
namespace ExcelImport_PartsLibrary
{
    /// <summary>
    /// Class TSNPlugIn.
    /// </summary>
    /// <remarks>This is the main class of the plugin.</remarks>
    public class TSNPlugIn : SNPlugInAncestorBase
    {
        #region Plugin Constructor - DO NOT CHANGE!!!

        /// <summary>
        /// Plugin constructor - DO NOT CHANGE!!!
        /// </summary>
        /// <param name="ASNApp">The SN application.</param>
        /// <param name="ASNPoke">The SNPoke interface.</param>
        public TSNPlugIn(ISNApp ASNApp, ISNPokeIntf ASNPoke/*,ISTDatabase ASTDatabase*/)
            : base(ASNApp, ASNPoke /*, ASTDatabase*/)
        {
            // Add constructor code here
        }

        #endregion

        #region General Plugin Settings

        /// <summary>
        /// This is the plugin name displayed on the toolbar.
        /// </summary>
        /// <value>The plug in description.</value>
        public override string PlugInDescription
        {
            get
            {
                return "SN C# Plugin";
            }
        }

        /// <summary>
        /// This text will show in the tool tip for the plugin button
        /// </summary>
        /// <value>The plug in explanation.</value>
        public override string PlugInExplenation
        {
            get
            {
                return "This is a template for a SIGMANEST C# Plugin.";
            }
        }

        /// <summary>
        /// Name of the company or person who developed the plugin
        /// </summary>
        /// <value>The author.</value>
        public override string Author
        {
            get
            {
                return "Author Name";
            }
        }

        /// <summary>
        /// Plugin version
        /// NOTE : When updating ver no also update the
        /// version info in the project Assembly.cs file
        /// </summary>
        /// <value>The version.</value>
        public override string Version
        {
            get
            {
                return "1.0.0.0";
            }
        }
        /// <summary>
        /// Date plugin was created
        /// </summary>
        /// <value>The date created.</value>
        public override double DateCreated
        {
            get
            {
                return DateTime.Today.ToOADate();
            }
        }

        /// <summary>
        /// Not used at this time - WIP
        /// </summary>
        /// <value>The type of the authorization.</value>
        public override byte AuthorizationType
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Not used at this time - WIP
        /// </summary>
        /// <value>The authorization unique identifier.</value>
        public override string AuthorizationGUID
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }

        /// <summary>
        /// Set the location where the plugin can be execute from
        /// what tab in SigmaNEST
        /// </summary>
        /// <param name="ALocation">a location.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public override bool ButtonOnLocation(Byte ALocation)
        {
            bool BtnLocation = false;

            switch (ALocation)
            {
                case SNPlugInIntTypes.ButtonLocation_Default: { BtnLocation = true; };
                    break;
                case SNPlugInIntTypes.ButtonLocation_WorkSpace: { BtnLocation = true; };
                    break;
                case SNPlugInIntTypes.ButtonLocation_CAD: { BtnLocation = true; };
                    break;
                case SNPlugInIntTypes.ButtonLocation_NestingManual: { BtnLocation = true; };
                    break;
                case SNPlugInIntTypes.ButtonLocation_NestingNC: { BtnLocation = true; };
                    break;
                case SNPlugInIntTypes.ButtonLocation_NestingDetail: { BtnLocation = true; };
                    break;
                case SNPlugInIntTypes.ButtonLocation_PartMode: { BtnLocation = true; };
                    break;
                case SNPlugInIntTypes.ButtonLocation_PartModeDetail: { BtnLocation = true; };
                    break;
                case SNPlugInIntTypes.ButtonLocation_Help: { BtnLocation = true; };
                    break;
                case SNPlugInIntTypes.ButtonLocation_Modify: { BtnLocation = true; };
                    break;
                default:
                    { BtnLocation = false; };
                    break;
            }
            return BtnLocation;
        }

        /// <summary>
        /// If set to true the config button for this plugin
        /// is enabled in the plugin manager - only when a config
        /// setup is used e.g. set a output path.
        /// </summary>
        /// <value><c>true</c> if this instance can configure; otherwise, <c>false</c>.</value>
        public override bool CanConfigure
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Use this method to broadcast to SN if your PlugIn
        /// has a MAIN EXECUTE Function Your plugin DOES NOT NECESARELY need to
        /// have a Main Execute Function - In that case set the result send back to SN FALSE.
        /// </summary>
        /// <value><c>true</c> if this instance can execute; otherwise, <c>false</c>.</value>
        public override bool CanExecute
        {
            get
            {
                return true;
            }
        }

        #endregion

        #region Config and Execute Events

        /// <summary>
        /// If CanConfig is enabled - execute any code here for config
        /// e.g. display a dlg and allow user to set a Save to Path.
        /// </summary>
        /// <param name="AParameters">optional parameters passed in through batch commands.</param>
        public override void Configure([MarshalAs(UnmanagedType.LPWStr)] string AParameters)
        {
            // This is an example config dialog that writes to an INI file
            IniFile iniFile = new IniFile(GetConfigFile_PathNameExt("INI", 0));
            frmConfig FormConfig = new frmConfig(SNApp, iniFile);
            FormConfig.ShowDialog();
            FormConfig.Dispose();
        }

        /// <summary>
        /// This function will be called by SN when ever the PlugIn is to be executed.
        /// This Action can be initiated by either the user clicking on the Ribbon Bar PlugIn Button
        /// or whenever the PlugIns is Called from API or BATCH command.
        /// </summary>
        /// <param name="AParameters">optional parameters passed in through batch commands.</param>
        public override void Execute([MarshalAs(UnmanagedType.LPWStr)] string AParameters)
        {
            // This is an example execution dialog that has some example functions
            frmExecute FormExecute = new frmExecute(SNApp);
            FormExecute.ShowDialog();
            FormExecute.Dispose();
        }

        #endregion

        #region Plugin Event Methods - Add code here for each enabled event in the Exports class

        /// <summary>
        /// When a part is saved in SigmaNEST
        /// This event is fired.
        /// </summary>
        /// <param name="APart">a part.</param>
        public void OnPartSave(ISNPartObj APart)
        {
            // This is an example event procedure which reads the INI file
            IniFile iniFile = new IniFile(GetConfigFile_PathNameExt("INI", 0));
            string EventMsg = iniFile.IniReadValue("Settings", "EventMessage");
            EventMsg = (EventMsg != "") ? EventMsg : "Hello World";
            MessageBox.Show(EventMsg, "OnPartSave Event");
        }

        /// <summary>
        /// When a part is saved in SigmaNEST this event
        /// is fired just before the save command is executed.
        /// </summary>
        /// <param name="APart">a part.</param>
        public void BeforePartSave(ISNPartObj APart)
        {
            MessageBox.Show("SigmaNEST Plugin - BeforePartSave Event");
        }

        /// <summary>
        /// After a part is created This event is fired.
        /// </summary>
        /// <param name="APart">a part.</param>
        public void AfterPartCreate(ISNPartObj APart)
        {
            MessageBox.Show("SigmaNEST Plugin - AfterPartCreate Event");
        }

        /// <summary>
        /// When you selected edit part in SigmaNEST
        /// This event is fired before the edit dialog
        /// opens.
        /// </summary>
        /// <param name="APart">a part.</param>
        public void BeforePartEdit(ISNPartObj APart)
        {
            MessageBox.Show("SigmaNEST Plugin - BeforePartEdit Event");
        }

        /// <summary>
        /// When you edit a part in SigmaNEST
        /// This event is fired before the edit dialog
        /// closes
        /// </summary>
        /// <param name="APart">a part.</param>
        public void AfterPartEdit(ISNPartObj APart)
        {
            MessageBox.Show("SigmaNEST Plugin - AfterPartEdit Event");
        }

        /// <summary>
        /// This event is fired when a sheet is saved.
        /// This can be from the Sheets List or in batch
        /// </summary>
        /// <param name="ASheet">a sheet.</param>
        public void OnSheetSave(ISNSheetObj ASheet)
        {
            MessageBox.Show("SigmaNEST Plugin - OnSheetSave Event");
        }

        /// <summary>
        /// When a remnant is created (Crop or from a drawing(create Sheet))
        /// this event is fired -
        /// </summary>
        /// <param name="ASheet">a sheet.</param>
        public void BeforeRemnantCreate(ISNSheetObj ASheet)
        {
            MessageBox.Show("SigmaNEST Plugin - BeforeRemnantCreate Event");
        }

        /// <summary>
        /// When a remnant is saved
        /// this event is fired -
        /// </summary>
        /// <param name="ASheet">a sheet.</param>
        public void BeforeRemnantSave(ISNSheetObj ASheet)
        {
            MessageBox.Show("SigmaNEST Plugin - BeforeRemnantSave Event");
        }

        /// <summary>
        /// Before a nest is posted in SigmaNEST this
        /// event is fired - e.g make sure all parts
        /// on the nest has NC
        /// </summary>
        /// <param name="ANest">a nest.</param>
        public void BeforePost(ISNNestObj ANest)
        {
            MessageBox.Show("SigmaNEST Plugin - BeforePost Event");
        }

        /// <summary>
        /// When you post a nest in SigmaNEST
        /// this event fires as the program is created
        /// </summary>
        /// <param name="ANest">a nest.</param>
        public void OnPost(ISNNestObj ANest)
        {
            MessageBox.Show("SigmaNEST Plugin - OnPost Event");
        }

        /// <summary>
        /// When posting a Task (All layouts).
        /// </summary>
        /// <param name="ATask">a task.</param>
        public void OnTaskPost(ISNTaskObj ATask)
        {
            MessageBox.Show("SigmaNEST Plugin - OnTaskPost Event");
        }

        /// <summary>
        /// After a program is created this event fires.
        /// </summary>
        public void OnAfterPost()
        {
            MessageBox.Show("SigmaNEST Plugin - OnAfterPost Event");
        }

        /// <summary>
        /// before a program is created from part mode this
        /// event is fired.
        /// </summary>
        /// <param name="APart">a part.</param>
        public void BeforePostPartMode(ISNPartObj APart)
        {
            MessageBox.Show("SigmaNEST Plugin - BeforePostPartMode Event");
        }

        /// <summary>
        /// When a program is created for a single part from Part mode
        /// </summary>
        /// <param name="APart">a part.</param>
        public void OnPostPartMode(ISNPartObj APart)
        {
            MessageBox.Show("SigmaNEST Plugin - OnPostPartMode Event");
        }

        /// <summary>
        /// after a program is created for a single part from Part mode
        /// </summary>
        public void OnAfterPostPartMode()
        {
            MessageBox.Show("SigmaNEST Plugin - OnAfterPostPartMode Event");
        }

        /// <summary>
        /// When SigmaNEST starts - only fires after the plugin is created
        /// </summary>
        public void OnSNStartUp()
        {
            MessageBox.Show("SigmaNEST Plugin - OnSNStartUp Event");
        }

        /// <summary>
        /// When a WS is saved
        /// </summary>
        public void OnWSSave()
        {
            MessageBox.Show("SigmaNEST Plugin - OnWSSave Event");
        }

        /// <summary>
        /// When a WS is loaded
        /// </summary>
        public void OnWSLoad()
        {
            MessageBox.Show("SigmaNEST Plugin - OnWSLoad Event");
        }

        /// <summary>
        /// when a task is created this event is fired - includes auto task
        /// </summary>
        /// <param name="ATask">a task.</param>
        public void OnTaskCreate(ISNTaskObj ATask)
        {
            MessageBox.Show("SigmaNEST Plugin - OnTaskCreate Event");
        }

        /// <summary>
        /// When a WO is created - includes batch
        /// </summary>
        /// <param name="ASNWorkOrder">The asn work order.</param>
        public void OnWOCreate(ISNWorkOrderObj ASNWorkOrder)
        {
            MessageBox.Show("SigmaNEST Plugin - OnWOCreate Event");
        }

        /// <summary>
        /// fires when a part is added to a WO
        /// </summary>
        /// <param name="APart">a part.</param>
        public void OnAddPartToWorkOrder(ISNWorkOrderPartObj APart)
        {
            MessageBox.Show("SigmaNEST Plugin - OnAddPartToWorkOrder Event");
        }

        /// <summary>
        /// After a program is updated
        /// NOTE - NOT USED
        /// </summary>
        /// <param name="ASNProgramObj">The program object.</param>
        public void AfterProgUpdate(ISNProgramObj ASNProgramObj)
        {
            MessageBox.Show("SigmaNEST Plugin - AfterProgUpdate Event");
        }

        /// <summary>
        /// Do not remove the [return: MarshalAs(.....
        /// </summary>
        /// <param name="ACntSheet">a count sheet.</param>
        /// <param name="ASheetNamePrefix">a sheet name prefix.</param>
        /// <param name="AMaterial">a material.</param>
        /// <param name="AThickness">a thickness.</param>
        /// <returns>Return the created remnant name</returns>
        [return: MarshalAs(UnmanagedType.LPWStr)]
        public string OnGetRemName(int ACntSheet, [MarshalAs(UnmanagedType.LPWStr)] string ASheetNamePrefix, [MarshalAs(UnmanagedType.LPWStr)] string AMaterial, double AThickness)
        {
            return "";
        }

        /// <summary>
        /// Do not remove the [return: MarshalAs(.....
        /// </summary>
        /// <param name="ACntSheet">a count sheet.</param>
        /// <param name="ASheetNamePrefix">a sheet name prefix.</param>
        /// <returns>Returns a new Sheet Name</returns>
        [return: MarshalAs(UnmanagedType.LPWStr)]
        public string OnGetSheetName(int ACntSheet, [MarshalAs(UnmanagedType.LPWStr)] string ASheetNamePrefix)
        {
            return "";
        }

        /// <summary>
        /// When a program is updated this event fires includes
        /// program update from batch
        /// </summary>
        public void TimerEvent()
        {
            MessageBox.Show("SigmaNEST Plugin - TimerEvent Event");
        }

        /// <summary>
        /// When a program is updated this event fires includes
        /// program update from batch
        /// </summary>
        /// <param name="AProgramRecord">a program record.</param>
        public void OnProgUpdate(ISNProgramObj AProgramRecord)
        {
            MessageBox.Show("SigmaNEST Plugin - OnProgUpdate Event");
        }

        /// <summary>
        /// When a quote is submitted this event fires
        /// </summary>
        /// <param name="aQuoteNumber">a quote number.</param>
        public void OnQuoteSubmit([MarshalAs(UnmanagedType.LPWStr)] string aQuoteNumber)
        {
            MessageBox.Show("SigmaNEST Plugin - OnQuoteSubmit Event");
        }

        /// <summary>
        /// When a quote is submitted this event fires
        /// </summary>
        /// <param name="aQuoteNumber">a quote number.</param>
        public void OnBeforeQuoteSubmit([MarshalAs(UnmanagedType.LPWStr)] string aQuoteNumber)
        {
            MessageBox.Show("SigmaNEST Plugin - OnBeforeQuoteSubmit Event");
        }

        /// <summary>
        /// When a quote is converted to WO this event fires
        /// </summary>
        /// <param name="aQuoteNumber">a quote number.</param>
        /// <param name="aOrderNumber">an order number.</param>
        /// <param name="aCustomer">a customer.</param>
        /// <param name="aCustomerPO">a customer po.</param>
        /// <param name="aWONumber">a wo number.</param>
        /// <param name="aDueDate">a due date.</param>
        public void OnConvertQuoteToWO([MarshalAs(UnmanagedType.LPWStr)] string aQuoteNumber, [MarshalAs(UnmanagedType.LPWStr)] string aOrderNumber, [MarshalAs(UnmanagedType.LPWStr)] string aCustomer, [MarshalAs(UnmanagedType.LPWStr)] string aCustomerPO, [MarshalAs(UnmanagedType.LPWStr)] string aWONumber, [MarshalAs(UnmanagedType.AsAny)] DateTime aDueDate)
        {
            MessageBox.Show("SigmaNEST Plugin - OnConvertQuoteToWO Event");
        }

        #endregion

    }

    /// <summary>
    /// Class Exports.
    /// </summary>
    /// <remarks>
    /// This is the exports class of the C# plugin. Because C# does not support 
    /// exporting unmanaged methods natively, there is an IL rewriter (DllExport.exe) 
    /// handling this as a post-build event. Because of this only uncomment the 
    /// methods you intend to use in your plugin.
    /// 
    /// DO NOT CHANGE THE SIGNATURE OF ANY EVENT OR THE [DllExport] Attribute
    /// 
    /// To enable an event, remove the // characters from that event here. To use 
    /// an event, add the code to be executed for these enabled events to the plugin 
    /// event methods in the TSNPlugin class.
    /// 
    /// e.g. [DllExport]
    /// [DllExport("OnPartSave", CallingConvention.StdCall)]
    /// 
    /// e.g.SIGNATURE
    /// public static void OnPartSave(ISNPartObj APart)
    /// 
    /// </remarks>
    public static class Exports
    {

        #region SigmaNEST Plugin Exports

        #region Entry Point - DO NOT CHANGE!!

        /// <summary>
        /// The SN plugin handle.
        /// </summary>
        public static TSNPlugIn GSNPlugInHandle2;
        /// <summary>
        /// Creates the c sharp plugin.
        /// </summary>
        /// <param name="GSNPlugInHandle">The SN plugin handle.</param>
        /// <param name="ASNApp">The SN application.</param>
        /// <param name="ASNPoke">The SNPoke interface.</param>
        [DllExport("CreateCSharpPlugin", CallingConvention.StdCall)]
        public static void CreateCSharpPlugin([MarshalAs(UnmanagedType.Interface)]out ISNPlugInInt GSNPlugInHandle, ISNApp ASNApp, ISNPokeIntf ASNPoke)//, ISTDatabase ASTDatabase)
        {
            GSNPlugInHandle2 = new TSNPlugIn(ASNApp, ASNPoke/*, ASTDatabase*/);
            GSNPlugInHandle = GSNPlugInHandle2 as ISNPlugInInt;
        }

        #endregion
        
        /// <summary>
        /// Called when a part is saved.
        /// </summary>
        /// <param name="APart">a part.</param>
        [DllExport("OnPartSave", CallingConvention.StdCall)]
        public static void OnPartSave(ISNPartObj APart)
        {
            GSNPlugInHandle2.OnPartSave(APart);
        }

        ///// <summary>
        ///// Before the part is saved.
        ///// </summary>
        ///// <param name="APart">a part.</param>
        //[DllExport("BeforePartSave", CallingConvention.StdCall)]
        //public static void BeforePartSave(ISNPartObj APart)
        //{
        //    GSNPlugInHandle2.BeforePartSave(APart);
        //}
        //
        ///// <summary>
        ///// After the part is created.
        ///// </summary>
        ///// <param name="APart">a part.</param>
        //[DllExport("AfterPartCreate", CallingConvention.StdCall)]
        //public static void AfterPartCreate(ISNPartObj APart)
        //{
        //    GSNPlugInHandle2.AfterPartCreate(APart);
        //}
        //
        ///// <summary>
        ///// Before the part is edited.
        ///// </summary>
        ///// <param name="APart">a part.</param>
        //[DllExport("BeforePartEdit", CallingConvention.StdCall)]
        //public static void BeforePartEdit(ISNPartObj APart)
        //{
        //    GSNPlugInHandle2.BeforePartEdit(APart);
        //}
        //
        ///// <summary>
        ///// After the part is edited.
        ///// </summary>
        ///// <param name="APart">a part.</param>
        //[DllExport("AfterPartEdit", CallingConvention.StdCall)]
        //public static void AfterPartEdit(ISNPartObj APart)
        //{
        //    GSNPlugInHandle2.AfterPartEdit(APart);
        //}
        //
        ///// <summary>
        ///// Called when a sheet is saved.
        ///// </summary>
        ///// <param name="ASheet">a sheet.</param>
        //[DllExport("OnSheetSave", CallingConvention.StdCall)]
        //public static void OnSheetSave(ISNSheetObj ASheet)
        //{
        //    GSNPlugInHandle2.OnSheetSave(ASheet);
        //}
        //
        ///// <summary>
        ///// Before the remnant is created.
        ///// </summary>
        ///// <param name="ASheet">a sheet.</param>
        //[DllExport("BeforeRemnantCreate", CallingConvention.StdCall)]
        //public static void BeforeRemnantCreate(ISNSheetObj ASheet)
        //{
        //    GSNPlugInHandle2.BeforeRemnantCreate(ASheet);
        //}
        //
        ///// <summary>
        ///// Before the remnant is saved.
        ///// </summary>
        ///// <param name="ASheet">a sheet.</param>
        //[DllExport("BeforeRemnantSave", CallingConvention.StdCall)]
        //public static void BeforeRemnantSave(ISNSheetObj ASheet)
        //{
        //    GSNPlugInHandle2.BeforeRemnantSave(ASheet);
        //}
        //
        ///// <summary>
        ///// Before posting.
        ///// </summary>
        ///// <param name="ANest">a nest.</param>
        //[DllExport("BeforePost", CallingConvention.StdCall)]
        //public static void BeforePost(ISNNestObj ANest)
        //{
        //    GSNPlugInHandle2.BeforePost(ANest);
        //}
        //
        ///// <summary>
        ///// Called when posting.
        ///// </summary>
        ///// <param name="ANest">a nest.</param>
        //[DllExport("OnPost", CallingConvention.StdCall)]
        //public static void OnPost(ISNNestObj ANest)
        //{
        //    GSNPlugInHandle2.OnPost(ANest);
        //}
        //
        ///// <summary>
        ///// Called when posting all.
        ///// </summary>
        ///// <param name="ATask">a task.</param>
        //[DllExport("OnTaskPost", CallingConvention.StdCall)]
        //public static void OnTaskPost(ISNTaskObj ATask)
        //{
        //    GSNPlugInHandle2.OnTaskPost(ATask);
        //}
        //
        ///// <summary>
        ///// Called when after posting.
        ///// </summary>
        //[DllExport("OnAfterPost", CallingConvention.StdCall)]
        //public static void OnAfterPost()
        //{
        //    GSNPlugInHandle2.OnAfterPost();
        //}
        //
        ///// <summary>
        ///// Before posting in part mode.
        ///// </summary>
        ///// <param name="APart">a part.</param>
        //[DllExport("BeforePostPartMode", CallingConvention.StdCall)]
        //public static void BeforePostPartMode(ISNPartObj APart)
        //{
        //    GSNPlugInHandle2.BeforePostPartMode(APart);
        //}
        //
        ///// <summary>
        ///// Called when posting in part mode.
        ///// </summary>
        ///// <param name="APart">a part.</param>
        //[DllExport("OnPostPartMode", CallingConvention.StdCall)]
        //public static void OnPostPartMode(ISNPartObj APart)
        //{
        //    GSNPlugInHandle2.OnPostPartMode(APart);
        //}
        //
        ///// <summary>
        ///// Called when after posting in part mode.
        ///// </summary>
        //[DllExport("OnAfterPostPartMode", CallingConvention.StdCall)]
        //public static void OnAfterPostPartMode()
        //{
        //    GSNPlugInHandle2.OnAfterPostPartMode();
        //}
        //
        ///// <summary>
        ///// Called when SN start up.
        ///// </summary>
        //[DllExport("OnSNStartUp", CallingConvention.StdCall)]
        //public static void OnSNStartUp()
        //{
        //    GSNPlugInHandle2.OnSNStartUp();
        //}
        //
        ///// <summary>
        ///// Called when ws save.
        ///// </summary>
        //[DllExport("OnWSSave", CallingConvention.StdCall)]
        //public static void OnWSSave()
        //{
        //    GSNPlugInHandle2.OnWSSave();
        //}
        //
        ///// <summary>
        ///// Called when ws load.
        ///// </summary>
        //[DllExport("OnWSLoad", CallingConvention.StdCall)]
        //public static void OnWSLoad()
        //{
        //    GSNPlugInHandle2.OnWSLoad();
        //}
        //
        ///// <summary>
        ///// Called when task create.
        ///// </summary>
        ///// <param name="ATask">a task.</param>
        //[DllExport("OnTaskCreate", CallingConvention.StdCall)]
        //public static void OnTaskCreate(ISNTaskObj ATask)
        //{
        //    GSNPlugInHandle2.OnTaskCreate(ATask);
        //}
        //
        ///// <summary>
        ///// Called when wo create.
        ///// </summary>
        ///// <param name="ASNWorkOrder">The SN work order.</param>
        //[DllExport("OnWOCreate", CallingConvention.StdCall)]
        //public static void OnWOCreate(ISNWorkOrderObj ASNWorkOrder)
        //{
        //    GSNPlugInHandle2.OnWOCreate(ASNWorkOrder);
        //}
        //
        ///// <summary>
        ///// Called when adding part to work order.
        ///// </summary>
        ///// <param name="APart">a part.</param>
        //[DllExport("OnAddPartToWorkOrder", CallingConvention.StdCall)]
        //public static void OnAddPartToWorkOrder(ISNWorkOrderPartObj APart)
        //{
        //    GSNPlugInHandle2.OnAddPartToWorkOrder(APart);
        //}
        //
        ///// <summary>
        ///// Called when program update.
        ///// </summary>
        ///// <param name="AProgramRecord">a program record.</param>
        //[DllExport("OnProgUpdate", CallingConvention.StdCall)]
        //public static void OnProgUpdate(ISNProgramObj AProgramRecord)
        //{
        //    GSNPlugInHandle2.OnProgUpdate(AProgramRecord);
        //}
        //
        ///// <summary>
        ///// After the program update.
        ///// </summary>
        ///// <param name="ASNProgramObj">The SN program object.</param>
        //[DllExport("AfterProgUpdate", CallingConvention.StdCall)]
        //public static void AfterProgUpdate(ISNProgramObj ASNProgramObj)
        //{
        //    GSNPlugInHandle2.AfterProgUpdate(ASNProgramObj);
        //}
        //
        ///// <summary>
        ///// Called when getting the remnant name.
        ///// </summary>
        ///// <param name="ACntSheet">sheet count.</param>
        ///// <param name="ASheetNamePrefix">sheet name prefix.</param>
        ///// <param name="AMaterial">material.</param>
        ///// <param name="AThickness">thickness.</param>
        ///// <returns>System.String.</returns>
        //[return: MarshalAs(UnmanagedType.LPWStr)]
        //[DllExport("OnGetRemName", CallingConvention.StdCall)]
        //public static string OnGetRemName(int ACntSheet, [MarshalAs(UnmanagedType.LPWStr)] string ASheetNamePrefix, [MarshalAs(UnmanagedType.LPWStr)] string AMaterial, double AThickness)
        //{
        //    return GSNPlugInHandle2.OnGetRemName(ACntSheet, ASheetNamePrefix, AMaterial, AThickness);
        //}
        //
        ///// <summary>
        ///// Called when getting the sheet name.
        ///// </summary>
        ///// <param name="ACntSheet">sheet count.</param>
        ///// <param name="ASheetNamePrefix">sheet name prefix.</param>
        ///// <returns>System.String.</returns>
        //[return: MarshalAs(UnmanagedType.LPWStr)]
        //[DllExport("OnGetSheetName", CallingConvention.StdCall)]
        //public static string OnGetSheetName(int ACntSheet, [MarshalAs(UnmanagedType.LPWStr)] string ASheetNamePrefix)
        //{
        //    return GSNPlugInHandle2.OnGetSheetName(ACntSheet, ASheetNamePrefix);
        //}
        //
        ///// <summary>
        ///// Timer event.
        ///// </summary>
        //[DllExport("TimerEvent", CallingConvention.StdCall)]
        //public static void TimerEvent()
        //{
        //    GSNPlugInHandle2.TimerEvent();
        //}
        //
        ///// <summary>
        ///// Called when quote submit.
        ///// </summary>
        ///// <param name="aQuoteNumber">quote number.</param>
        //[DllExport("OnQuoteSubmit", CallingConvention.StdCall)]
        //public static void OnQuoteSubmit([MarshalAs(UnmanagedType.LPWStr)] string aQuoteNumber)
        //{
        //    GSNPlugInHandle2.OnQuoteSubmit(aQuoteNumber);
        //}
        //
        ///// <summary>
        ///// Called when before quote submit.
        ///// </summary>
        ///// <param name="aQuoteNumber">quote number.</param>
        //[DllExport("OnBeforeQuoteSubmit", CallingConvention.StdCall)]
        //public static void OnBeforeQuoteSubmit([MarshalAs(UnmanagedType.LPWStr)] string aQuoteNumber)
        //{
        //    GSNPlugInHandle2.OnBeforeQuoteSubmit(aQuoteNumber);
        //}
        //
        ///// <summary>
        ///// Called when converting quote to wo.
        ///// </summary>
        ///// <param name="aQuoteNumber">quote number.</param>
        ///// <param name="aOrderNumber">order number.</param>
        ///// <param name="aCustomer">customer.</param>
        ///// <param name="aCustomerPO">customer po.</param>
        ///// <param name="aWONumber">wo number.</param>
        ///// <param name="aDueDate">due date.</param>
        //[DllExport("OnConvertQuoteToWO", CallingConvention.StdCall)]
        //public static void OnConvertQuoteToWO([MarshalAs(UnmanagedType.LPWStr)] string aQuoteNumber, [MarshalAs(UnmanagedType.LPWStr)] string aOrderNumber, [MarshalAs(UnmanagedType.LPWStr)] string aCustomer, [MarshalAs(UnmanagedType.LPWStr)] string aCustomerPO, [MarshalAs(UnmanagedType.LPWStr)] string aWONumber, [MarshalAs(UnmanagedType.AsAny)] DateTime aDueDate)
        //{
        //    GSNPlugInHandle2.OnConvertQuoteToWO(aQuoteNumber, aOrderNumber, aCustomer, aCustomerPO, aWONumber, aDueDate);
        //}

        #endregion

    }

}