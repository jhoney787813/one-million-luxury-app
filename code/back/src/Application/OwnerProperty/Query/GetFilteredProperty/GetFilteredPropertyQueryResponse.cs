namespace Application.OwnerProperty.GetFilteredProperty
{
    public class GetFilteredPropertyQueryResponse
    {
        public GetFilteredPropertyQueryResponse(long idOwner, string ownerName, string propertyName, string propertyAddress, decimal? price, string imageUrl)
        {
            IdOwner = idOwner;
            OwnerName = ownerName;
            PropertyName = propertyName;
            PropertyAddress = propertyAddress;
            Price = price;
            ImageUrl = imageUrl;
        }

        public long IdOwner { set; get; }
        public string OwnerName { set; get; }
        public string PropertyName { set; get; }
        public string PropertyAddress { set; get; }
        public decimal? Price { set; get; }
        public string ImageUrl { set; get; }
    }
}

