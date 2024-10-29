using System.Net.NetworkInformation;
using Yarp.ReverseProxy.Configuration;

namespace ApiGateway.Configurations
{
    public static class BasicConfig
    {
        public static IReadOnlyList<RouteConfig> GetRoutes()
        {
            return new[]
            {
                // Define the first route
                new RouteConfig
                {
                    RouteId = "product-route", // Unique ID for this route
                    ClusterId = "product-cluster", // This ID is the cluster of this route maps to
                    Match = new RouteMatch
                    {
                        Path= "/api/products/{**catch-all}" // URL Path patther for this route(Product)
                    }
                },
                //Define Order Route
                new RouteConfig
                {
                    RouteId = "order-route", // Unique ID for this route
                    ClusterId = "order-cluster", // This ID is the cluster of this route maps to
                    Match = new RouteMatch
                    {
                        Path= "/api/orders/{**catch-all}" // URL Path patther for this route(order)
                    }
                },
            };
        }

        public static IReadOnlyList<ClusterConfig> GetClusters() 
        {
            return new[] {
                // Define the Products Cluster
                new ClusterConfig
                {
                    ClusterId = "product-cluster", // Unique ID for the cluster
                    Destinations =new Dictionary<String, DestinationConfig>
                    {
                        {
                            "product-destination" , new DestinationConfig{Address = "https://localhost:5002"}
                        }
                    }
                },
                    // Define the Order Cluster
                new ClusterConfig
                {
                    ClusterId = "order-cluster", // Unique ID for the cluster
                    Destinations =new Dictionary<String, DestinationConfig>
                    {
                        {
                            "order-destination" , new DestinationConfig{Address = "https://localhost:5001"}
                        }
                    }
                }
            };
        
        }
    }
}
