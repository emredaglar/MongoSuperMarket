﻿namespace MongoSuperMarket.Dtos.SellingDtos
{
	public class ResultSellingDto
	{
		public string SellingId { get; set; }
		public string ProductId { get; set; }
		public int Count { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime SellingDate { get; set; }
		public string ProductName { get; set; }
		public decimal ProductPrice { get; set; }
		public string ProductImage { get; set; }
	}
}
