﻿namespace MongoSuperMarket.Dtos.ProductDtos
{
	public class CreateProductDto
	{
		public string ProductName { get; set; }
		public int ProductStock { get; set; }
		public decimal ProductPrice { get; set; }
		public string ProductImage { get; set; }
		public string CategoryId { get; set; }
		public string CategoryName { get; set; }
	}
}
