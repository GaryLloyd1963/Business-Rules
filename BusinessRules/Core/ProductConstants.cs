namespace BusinessRules.Core
{
    public class ProductConstants
    {
        public enum MainProductType
        {
            Physical = 0,
            NonPhysical
        }

        public enum SubProductType
        {
            Book = 0,
            Video,
            Membership,
            MembershipUpgrade                        
        }
    }
}