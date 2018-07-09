using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.WeiXin.Public
{
    public class WxPublicOptions : WxPublic, IOptions<WxPublic>
    {
        public WxPublic Value
        {
            get { return this; }
        }
    }
}
