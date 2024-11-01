using Yarp.ReverseProxy.Configuration;
using Yarp.ReverseProxy.LoadBalancing;
using Yarp.ReverseProxy.SessionAffinity;

namespace ApiGateway.Configurations
{
    public static class BasicConfig
    {
        public static IReadOnlyList<RouteConfig> GetRoutes()
        {
            return new[]
            {
                new RouteConfig
                {
                    RouteId = "product-route",
                    ClusterId = "product-cluster",
                    Match = new RouteMatch
                    {
                        Path = "/api/products/{**catch-all}"
                    }
                },
                new RouteConfig
                {
                    RouteId = "order-route",
                    ClusterId = "order-cluster",
                    Match = new RouteMatch
                    {
                        Path = "/api/orders/{**catch-all}"
                    }
                },
            };
        }

        public static IReadOnlyList<ClusterConfig> GetClusters()
        {
            return new[] {
               new ClusterConfig
{
    ClusterId = "product-cluster",

    SessionAffinity = new SessionAffinityConfig
    {
        Enabled = false,
        Policy = SessionAffinityConstants.Policies.Cookie,
        FailurePolicy = SessionAffinityConstants.FailurePolicies.Return503Error,
        AffinityKeyName = "MyAffinityKey" // Menambahkan AffinityKeyName
    },
    Destinations = new Dictionary<string, DestinationConfig>(StringComparer.OrdinalIgnoreCase)
    {
        {
            "product-destination1", new DestinationConfig()
            {
                Address = "https://localhost:5002"
            }
        },
        {
            "product-destination2", new DestinationConfig()
            {
                Address = "https://localhost:5003"
            }
        },
        {
            "product-destination3", new DestinationConfig()
            {
                Address = "https://localhost:5004"
            }
        }
    },
        LoadBalancingPolicy = LoadBalancingPolicies.RoundRobin,
},

                new ClusterConfig
                {
                    ClusterId = "order-cluster",
                    LoadBalancingPolicy = LoadBalancingPolicies.RoundRobin,  
                    Destinations = new Dictionary<string, DestinationConfig>
                    {
                        {
                            "order-destination", new DestinationConfig
                            {
                                Address = "https://localhost:5001"
                            }
                        }
                    }
                }
            };
        }
    }
}