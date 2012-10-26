using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZGE.Components;
using OpenTK;

namespace ZGE
{
    class ModelBehavior
    {
        ZApplication App;

        public ModelBehavior(ZApplication app)
        {
            App = app;
        }

        public void Update(Model model)
        {
            model.Rotation += new Vector3(0, 180.0f * (float) App.DeltaTime, 0);            
        }
    }
}
