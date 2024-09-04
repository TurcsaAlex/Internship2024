import { Component, Input } from '@angular/core';
import { ChartDataset, ChartOptions, ChartTypeRegistry } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';

export type CardChartData = {
  type: 'card';
  title: string;
  data: any;
  icon?: string;
}

type ChartData<T extends keyof ChartTypeRegistry> = {
  type: T;
  title: string;
  labels: any[];
  data: ChartDataset<T, number[]>[];
  options?: ChartOptions<T>;
  legend: boolean;
}

export type PieChartData = ChartData<'pie'>;
export type DonutChartData = ChartData<'doughnut'>;
export type LineChartData = ChartData<'line'>
export type BarChartData = ChartData<'bar'>

export type ChartType = CardChartData | PieChartData | DonutChartData | LineChartData | BarChartData;


@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrl: './chart.component.css',
  imports:[BaseChartDirective],
  standalone:true
})
export class ChartComponent {
  @Input() chart!: ChartType;
}
