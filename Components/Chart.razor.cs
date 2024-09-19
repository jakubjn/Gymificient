using BlazorBootstrap;
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
        public bool LegendVisible { get; set; } = true;

        [Parameter]
        public float Min { get; set; }

        [Parameter]
        public float Max { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public ChartType Type { get; set; }

        [Parameter]
        public string[] Data { get; set; }

        [Parameter]
        public string BackgroundColor { get; set; }

        [Parameter]
        public string[] Labels { get; set; }

        [Parameter]
        public string Class { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public bool TitleDisplay { get; set; }

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
                        y = new
                        {
                            Min,
                            Max,
                        }
                    },
                    Plugins = new
                    {
                        Legend = new
                        {
                            Display = LegendVisible
                        },
                        Title = new
                        {
                            Display = TitleDisplay,
                            Text = Title
                        }
                    }
                },

                Data = new
                {
                    Datasets = new[]
                    {
                        new {
                            Data,
                            BackgroundColor
                        }
                    },

                    Labels
                }
            };

            await JSRuntime.InvokeVoidAsync("setup", Id, config);
        }
    }
}
