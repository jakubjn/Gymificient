using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace GymSystem.Components
{
    public enum ChartType
    {
        pie,
        doughnut,
        bar
    }

    public partial class Chart
    {
        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public ChartType Type { get; set; }

        [Parameter]
        public string[] Data { get; set; }

        [Parameter]
        public string[] BackgroundColor { get; set; }

        [Parameter]
        public string[] Labels { get; set; }

        [Parameter]
        public string Class { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var config = new
            {
                Type = Type.ToString().ToLower(),
                Options = new
                {
                    Responsive = true,
                    Scales = new
                    {
                        
                    }
                },

                Data = new
                {
                    Datasets = new[]
                    {
                        new { 
                            Data = Data, 
                            BackgroundColor = BackgroundColor
                        }
                    },

                    Labels = Labels
                }
            };

            await JSRuntime.InvokeVoidAsync("setup", Id, config);
        }
    }
}
