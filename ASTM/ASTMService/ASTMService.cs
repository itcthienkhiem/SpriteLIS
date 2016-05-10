namespace ASTMService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading;

    using ASTM;

    public partial class ASTMService : ServiceBase
    {
        #region Constructors

        public ASTMService()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        public void Start()
        {
            try
            {
                ASTMController controller = new ASTMController();
                controller.connect();
                controller.start();
                Console.ReadLine();
                //controller.listenner();
                
            }
            catch (Exception ex)
            {
                throw new ASTMExeption(ex.Message);

            }
        }

        protected override void OnStart(string[] args)
        {
            Start();
        }

        protected override void OnStop()
        {
            Console.WriteLine("Hello word!");
        }

        #endregion Methods

        #region Other

        //protected override void OnStop()
        //{
        //}

        #endregion Other
    }
}