var builder = DistributedApplication.CreateBuilder(args);
var ProductService = builder.AddProject<Projects.Shopping_ProductService>("appservice-product");
var OrderService = builder.AddProject<Projects.Shopping_OrderService>("appservice-order");
builder.AddProject<Projects.Shopping_web>("frontend")
    .WithReference(ProductService)
    .WithReference(OrderService);
builder.Build().Run();
