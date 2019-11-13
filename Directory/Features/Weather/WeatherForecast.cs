namespace Directory.Features.Weather
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public static class WeatherForecast
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public class Query : IRequest<Response>
        {
            public Query(int numberOfDays = 5) => NumberOfDays = numberOfDays;
            public int NumberOfDays { get; set; }
        }

        public class Response
        {
            public Response() => Days = new List<Day>();
            public Response(IEnumerable<Day> days) => Days = days.ToList();
            public List<Day> Days { get; set; }
        }

        public class Day
        {
            public DateTime Date { get; set; }
            public int TemperatureC { get; set; }
            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
            public string? Summary { get; set; }
        }

        public class Handler : IRequestHandler<Query, Response>
        {
            public Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var rng = new Random();
                return Task.FromResult(new Response(
                    Enumerable.Range(1, request.NumberOfDays)
                        .Select(index => new Day
                        {
                            Date = DateTime.Now.AddDays(index),
                            TemperatureC = rng.Next(-20, 55),
                            Summary = Summaries[rng.Next(Summaries.Length)]
                        })
                    )
                );
            }
        }
    }
}
