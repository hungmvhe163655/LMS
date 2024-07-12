import { TrendingUp } from 'lucide-react';
import React from 'react';
import {
  CartesianGrid,
  Line,
  LineChart,
  XAxis,
  YAxis,
  Legend,
  Tooltip,
  ResponsiveContainer
} from 'recharts';

import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle
} from '@/components/ui/card';
import { ChartConfig, ChartContainer, ChartTooltipContent } from '@/components/ui/chart';

const chartData = [
  { date: '9th', activeTasks: 10, doneTasks: 5 },
  { date: '10th', activeTasks: 20, doneTasks: 10 },
  { date: '11th', activeTasks: 35, doneTasks: 15 },
  { date: '12th', activeTasks: 25, doneTasks: 20 },
  { date: '13th', activeTasks: 30, doneTasks: 25 }
];

const chartConfig = {
  activeTasks: {
    label: 'Active Tasks',
    color: 'hsl(var(--chart-1))'
  },
  doneTasks: {
    label: 'Done Tasks',
    color: 'hsl(var(--chart-2))'
  }
} satisfies ChartConfig;

const TaskOverallChart: React.FC = () => {
  return (
    <Card>
      <CardHeader>
        <CardTitle>Task Overview</CardTitle>
        <CardDescription>9th June - 13th June</CardDescription>
      </CardHeader>
      <CardContent>
        <ChartContainer config={chartConfig}>
          <ResponsiveContainer width='100%' height={300}>
            <LineChart data={chartData}>
              <CartesianGrid strokeDasharray='3 3' />
              <XAxis dataKey='date' />
              <YAxis />
              <Tooltip content={<ChartTooltipContent hideLabel />} />
              <Legend />
              <Line
                type='monotone'
                dataKey='activeTasks'
                stroke='hsl(var(--chart-1))'
                strokeWidth={2}
              />
              <Line
                type='monotone'
                dataKey='doneTasks'
                stroke='hsl(var(--chart-2))'
                strokeWidth={2}
              />
            </LineChart>
          </ResponsiveContainer>
        </ChartContainer>
      </CardContent>
      <CardFooter className='flex-col items-start gap-2 text-sm'>
        <div className='flex gap-2 font-medium leading-none'>
          Trending up by x% this month <TrendingUp className='size-4' />
        </div>
        <div className='leading-none text-muted-foreground'>
          Showing total tasks for the last x days
        </div>
      </CardFooter>
    </Card>
  );
};

export default TaskOverallChart;
