﻿namespace Shopping.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
