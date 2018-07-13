using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.WeiXin.Payment
{
    /// <summary>
    /// 场景信息
    /// </summary>
    public class SceneInfo
    {
        /// <summary>
        /// 门店idString(32)
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 门店名称String(64) 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 门店行政区划码,String(6)门店所在地行政区划码，详细见《最新县及县以上行政区划代码》
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// 门店详细地址,String(128)
        /// </summary>
        public string Address { get; set; }
    }
}
