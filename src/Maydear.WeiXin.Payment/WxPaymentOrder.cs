using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.WeiXin.Payment
{
    /// <summary>
    /// 
    /// </summary>
    public class WxPaymentOrder
    {

        /// <summary>
        ///  (必须)，公众账号ID，微信支付分配的公众账号ID（企业号corpid即为此appId）
        /// </summary>
        /// <remarks>
        /// String(32)
        /// </remarks>
        public string AppId { get; set; }

        /// <summary>
        /// (必须)，商户号，微信支付分配的商户号
        /// </summary>
        /// <remarks>
        /// String(32)
        /// </remarks>
        public string MchId { get; set; }

        /// <summary>
        /// 设备号，可以为终端设备号(门店号或收银设备ID)，PC网页或公众号内支付可以传"WEB"
        /// </summary>
        /// <remarks>
        /// String(32)
        /// </remarks>
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 随机字符串，长度要求在32位以内。推荐随机数生成算法
        /// </summary>
        /// <remarks>
        /// String(32)
        /// </remarks>
        public string NonceStr { get; set; }

        /// <summary>
        /// 签名，通过签名算法计算得出的签名值，详见签名生成算法
        /// </summary>
        /// <remarks>
        /// String(32)
        /// </remarks>
        public string Sign { get; set; }

        /// <summary>
        /// 签名类型，默认为MD5，支持HMAC-SHA256和MD5。
        /// </summary>
        /// <remarks>
        /// String(32)
        /// </remarks>
        public string SignType { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        /// <remarks>
        /// String(128) 
        /// </remarks>
        public string Body { get; set; }

        /// <summary>
        /// 商品详情
        /// </summary>
        /// <remarks>
        /// String(6000) 
        /// </remarks>
        public string Detail { get; set; }

        /// <summary>
        /// 附加数据，在查询API和支付通知中原样返回，可作为自定义参数使用。
        /// </summary>
        /// <remarks>
        /// String(127)
        /// </remarks>
        public string Attach { get; set; }

        /// <summary>
        /// 商户订单号，商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|* 且在同一个商户号下唯一。详见商户订单号
        /// </summary>
        /// <remarks>
        /// String(32)
        /// </remarks>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 标价币种，符合ISO 4217标准的三位字母代码，默认人民币：CNY，详细列表请参见货币类型
        /// </summary>
        public string FeeType { get; set; } = "CNY";

        /// <summary>
        ///  (必须)，标价金额，订单总金额，单位为分，详见支付金额
        /// </summary>
        /// <remarks>
        /// int
        /// </remarks>
        public int TotalFee { get; set; }

        /// <summary>
        ///  (必须)，终端IP,APP和网页支付提交用户端ip，Native支付填调用微信支付API的机器IP。
        /// </summary>
        /// <remarks>
        /// String(16) 
        /// </remarks>
        public string SpbillCreateIp { get; set; }

        /// <summary>
        ///  交易起始时间,订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。其他详见时间规则
        /// </summary>
        /// <remarks>
        /// String(14)
        /// </remarks>
        public string TimeStart { get; set; }

        /// <summary>
        ///  交易结束时间,订单失效时间，格式为yyyyMMddHHmmss，如2009年12月27日9点10分10秒表示为20091227091010。订单失效时间是针对订单号而言的，由于在请求支付的时候有一个必传参数prepay_id只有两小时的有效期，所以在重入时间超过2小时的时候需要重新请求下单接口获取新的prepay_id。其他详见时间规则.建议：最短失效时间间隔大于1分钟
        /// </summary>
        /// <remarks>
        /// String(14)
        /// </remarks>
        public string TimeExpire { get; set; }
        /// <summary>
        ///  订单优惠标记,订单优惠标记，使用代金券或立减优惠功能时需要的参数，说明详见代金券或立减优惠
        /// </summary>
        /// <remarks>
        /// String(32)
        /// </remarks>
        public string goods_tag { get; set; }

        /// <summary>
        ///  通知地址通知地址, http://www.weixin.qq.com/wxpay/pay.php	异步接收微信支付结果通知的回调地址，通知url必须为外网可访问的url，不能携带参数。
        /// </summary>
        /// <remarks>
        /// String(128)
        /// </remarks>
        public string NotifyUrl { get; set; }
        /// <summary>
        /// (必须)，交易类型, JSAPI 公众号支付, NATIVE 扫码支付,APP APP支付
        /// </summary>
        /// <remarks>
        /// String(16)
        /// </remarks>

        public string TradeType { get; set; }

        /// <summary>
        /// 商品ID,trade_type=NATIVE时（即扫码支付），此参数必传。此参数为二维码中包含的商品ID，商户自行定义。
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// 指定支付方式 no_credit 上传此参数no_credit--可限制用户不能使用信用卡支付
        /// </summary>
        public string LimitPay { get; set; }

        /// <summary>
        /// 用户标识,trade_type = JSAPI时（即公众号支付），此参数必传，此参数为微信用户在商户对应appid下的唯一标识。openid如何获取，可参考【获取openid】。企业号请使用【企业号OAuth2.0接口】获取企业号内成员userid，再调用【企业号userid转openid接口】进行转换
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// <code>
        /// {
        /// "store_info" : {
        /// "id": "SZTX001",
        /// "name": "腾大餐厅",
        /// "area_code": "440305",
        /// "address": "科技园中一路腾讯大厦" }
        /// }
        /// </code>
        ///  该字段用于上报场景信息，目前支持上报实际门店信息。该字段为JSON对象数据，对象格式为{"store_info":{"id": "门店ID","name": "名称","area_code": "编码","address": "地址" }} ，字段详细说明请点击行前的+展开
        /// </remarks>
        public string SceneInfo { get; set; }
    }
}
