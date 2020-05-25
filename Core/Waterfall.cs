﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChartsModel = DevExpress.Charts.Model;
using DevExpress.Utils;

namespace ChartExModelSpike {
    public static class Waterfall {
        public static ChartsModel.Chart Create() {
            var chart = new ChartsModel.CartesianChart();

            // Argument Axis
            chart.ArgumentAxis = new ChartsModel.Axis() {
                Position = ChartsModel.AxisPosition.Bottom,
                GridLinesVisible = false,
                GridLinesMinorVisible = false,
                TickmarksVisible = false,
                Visible = true
            };

            chart.ArgumentAxis.Label = new ChartsModel.AxisLabel(chart.ArgumentAxis) {
                EnableAntialiasing = DefaultBoolean.True,
                Visible = true
            };

            // Value Axis
            chart.ValueAxis = new ChartsModel.Axis() {
                Position = ChartsModel.AxisPosition.Left,
                GridLinesVisible = true,
                GridLinesMinorVisible = false,
                TickmarksVisible = true,
                Visible = true
            };

            chart.ValueAxis.Label = new ChartsModel.AxisLabel(chart.ValueAxis) {
                EnableAntialiasing = DefaultBoolean.True,
                Visible = true
            };

            // Series
            var series = new ChartsModel.WaterfallSeries {
                DisplayName = "Series1",
                LabelsVisibility = true
            };

            series.DataMembers[ChartsModel.DataMemberType.Argument] = "Name";
            series.DataMembers[ChartsModel.DataMemberType.Value] = "Amount";
            series.DataMembers[ChartsModel.DataMemberType.Color] = "PointColor";
            series.DataSource = WaterfallData.GetSampleData();

            series.Label = new ChartsModel.SeriesLabel(series) {
                EnableAntialiasing = DefaultBoolean.True,
                Position = ChartsModel.SeriesLabelPosition.Top
            };
            series.Appearance = new ChartsModel.SeriesAppearance() {
                Color = new ChartsModel.ColorARGB(0xff, 0x44, 0x72, 0xc4),
                LabelAppearance = new ChartsModel.SeriesLabelAppearance() {
                    LineVisible = false,
                    Border = new ChartsModel.Border() { Color = ChartsModel.ColorARGB.Transparent },
                    TextColor = new ChartsModel.ColorARGB(255, 0, 0, 0),
                    BackColor = ChartsModel.ColorARGB.Transparent
                }
            };

            if (series is ChartsModel.ISupportTransparencySeries seriesWithTransparency)
                seriesWithTransparency.Transparency = 0;

            chart.Series.Add(series);

            // Legend
            var legend = new ChartsModel.Legend {
                EnableAntialiasing = DefaultBoolean.True,
                LegendPosition = ChartsModel.LegendPosition.Top,
                Orientation = ChartsModel.LegendOrientation.Horizontal,
                Overlay = false
            };
            chart.Legend = legend;

            // Title
            var title = new ChartsModel.ChartTitle {
                EnableAntialiasing = DefaultBoolean.True,
                Lines = new string[] { "4th Quarter" }
            };
            chart.Titles.Add(title);

            //// Palette
            //chart.Palette = new ChartsModel.Palette();
            //chart.Palette.Entries.Add(new ChartsModel.PaletteEntry(new ChartsModel.ColorARGB(0xff, 0x44, 0x72, 0xc4)));
            //chart.Palette.Entries.Add(new ChartsModel.PaletteEntry(new ChartsModel.ColorARGB(0xff, 0xed, 0x7d, 0x31)));
            //chart.Palette.Entries.Add(new ChartsModel.PaletteEntry(new ChartsModel.ColorARGB(0xff, 0xcc, 0xcc, 0xcc)));

            return chart;
        }
    }

    public class WaterfallData {
        public WaterfallData(string name, double amount) {
            Name = name;
            Amount = amount;
        }

        public string Name { get; private set; }
        public double Amount { get; private set; }
        public int PointColor => (int)(Amount >= 0 ? 0xff4472c4 : 0xffed7d31);
        public bool IsTotal { get; set; }

        public static List<WaterfallData> GetSampleData() {
            List<WaterfallData> data = new List<WaterfallData>();
            data.Add(new WaterfallData("Revenue", 23201));
            data.Add(new WaterfallData("Cost of goods", -8192));
            data.Add(new WaterfallData("Revenue 2", 16384));
            data.Add(new WaterfallData("Expense", -12345));
            data.Add(new WaterfallData("Revenue 3", 3201));
            return data;
        }
    }
}