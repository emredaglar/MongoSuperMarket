﻿namespace MongoSuperMarket.Dtos.DiscountDtos
{
	public class UpdateDiscountDto
	{
		public string DiscountId { get; set; }
		public string Image { get; set; }
		public string DiscountPercent { get; set; }
		public string DiscountTitle { get; set; }
		public string Description { get; set; }
	}
}
