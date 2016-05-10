namespace ASTMConfig
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ASTMValiable : Dictionary<Object,object>
    {
        #region Methods

        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        #endregion Methods
    }
}