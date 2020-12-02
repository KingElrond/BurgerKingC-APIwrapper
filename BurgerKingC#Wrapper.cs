namespace Namespace {
    
    using requests;
    
    using xml.etree.ElementTree;
    
    using System.Linq;
    
    public static class Module {
        
        public static object BASE_URL = "http://bkm-cdn.tillster.com";
        
        public static object BASE_URL_2 = "https://bkm-native-prod.tillster.com";
        
        public class Promo {
            
            public Promo(object data) {
                this.promoCode = data["promoCode"];
                this.storePromoCode = data["storePromoCode"];
                this.startDate = data["startDate"];
                this.expirationDate = data["expirationDate"];
                this.remainingDays = data["remainingDays"];
                this.posSku = data["posSku"];
                this.maxRedemptions = data["maxRedemptions"];
                this.channel = data["channel"];
                this.orderDiscountPercentage = data["orderDiscountPercentage"];
                this.itemDiscountPercentage = data["itemDiscountPercentage"];
                this.orderFlatDiscountAmount = data["orderFlatDiscountAmount"];
                this.itemFlatDiscountAmount = data["itemFlatDiscountAmount"];
                this.mobilem8MenuSku = data["mobilem8MenuSku"];
                this.description = data["description"];
                this.displayName = data["displayName"];
                this.promoCodeType = data["promoCodeType"];
                this.parentPromoCodeId = data["parentPromoCodeId"];
                this.id = data["id"];
                this.medium = data["medium"];
                this.url = data["url"];
                this.loyaltyCost = data["loyaltyCost"];
                this.startDateTimeZone = data["startDateTimeZone"];
                this.expirationDateTimeZone = data["expirationDateTimeZone"];
                this.guestRedeemable = data["guestRedeemable"];
                this.offerType = data["offerType"];
                this.validModes = data["validModes"];
                this.props = Prop(data["props"]);
                this.status = Status(data["status"]);
            }
        }
        
        public class Status {
            
            public Status(object data) {
                this.@new = data["new"];
            }
        }
        
        public class Prop {
            
            public Prop(object data) {
                this.shortCodeImage = data["short_code_image"];
                this.couponImage = data["coupon_image"];
                this.priority = data["priority"];
                this.offerDetails = data["offer_details"];
                this.headline = data["headline"];
                this.menum8PruningPoint = data["menum8_pruning_point"];
            }
        }
        
        public static object retrieveCoupons() {
            var url = BASE_URL_2 + "/mobile-aggregation-service/rest/coupons";
            var allData = requests.get(url).json();
            return (from d in allData["loyaltyAppSession"]["promoOffers"]
                select Promo(d)).ToList();
        }
        
        public static object getEndpoints() {
            var data = requests.get(BASE_URL).text;
            var parsed = xml.etree.ElementTree.XML(data);
            var results = parsed.findall(".//{http://s3.amazonaws.com/doc/2006-03-01/}Key");
            return (from r in results
                select r.text).ToList();
        }
    }
}
