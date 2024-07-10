'use client';
import { TrendingUp } from 'lucide-react';
import React from 'react';
import { Label, Pie, PieChart } from 'recharts';

import { Button } from '@/components/ui/button';
import {
  ChartConfig,
  ChartContainer,
  ChartTooltip,
  ChartTooltipContent
} from '@/components/ui/chart';

const chartData = [
  { label: 'Offline Member', value: 12, fill: 'hsl(var(--chart-1))' },
  { label: 'Online Member', value: 22, fill: 'hsl(var(--chart-2))' }
];

const chartConfig = {
  value: {
    label: 'Value'
  },
  offlineMember: {
    label: 'Offline Member',
    color: 'hsl(var(--chart-1))'
  },
  onlineMember: {
    label: 'Online Member',
    color: 'hsl(var(--chart-2))'
  }
} satisfies ChartConfig;

const MemberReportChart: React.FC = () => {
  const totalMembers = React.useMemo(() => {
    return chartData.reduce((acc, curr) => acc + curr.value, 0);
  }, []);

  return (
    <div className='rounded-md bg-white p-4 shadow-md'>
      <div className='mb-4 flex justify-between'>
        <Button className='mr-2'>Member Report</Button>
        <Button className='mr-2'>Active Projects</Button>
        <Button>Device Report</Button>
      </div>
      <div className='mb-4'>
        <ChartContainer config={chartConfig} className='mx-auto aspect-square max-h-[250px]'>
          <PieChart>
            <ChartTooltip cursor={false} content={<ChartTooltipContent hideLabel />} />
            <Pie data={chartData} dataKey='value' nameKey='label' innerRadius={60} strokeWidth={5}>
              <Label
                content={({ viewBox }) => {
                  if (viewBox && 'cx' in viewBox && 'cy' in viewBox) {
                    return (
                      <text
                        x={viewBox.cx}
                        y={viewBox.cy}
                        textAnchor='middle'
                        dominantBaseline='middle'
                      >
                        <tspan
                          x={viewBox.cx}
                          y={viewBox.cy}
                          className='fill-foreground text-3xl font-bold'
                        >
                          {totalMembers.toLocaleString()}
                        </tspan>
                        <tspan
                          x={viewBox.cx}
                          y={(viewBox.cy || 0) + 24}
                          className='fill-muted-foreground'
                        >
                          Members
                        </tspan>
                      </text>
                    );
                  }
                }}
              />
            </Pie>
          </PieChart>
        </ChartContainer>
      </div>
      <div className='flex-col items-start gap-2 text-sm'>
        <div className='flex gap-2 font-medium leading-none'>
          Trending up by 5.2% this month <TrendingUp className='size-4' />
        </div>
        <div className='leading-none text-muted-foreground'>
          Showing total members for the last 6 months
        </div>
      </div>
    </div>
  );
};

export default MemberReportChart;
