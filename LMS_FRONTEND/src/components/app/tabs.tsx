import { Tabs, TabsContent, TabsList, TabsTrigger } from '@/components/ui/tabs';

import CommentSection from './comment-section';
import HistorySection from './history-section';

export function TabsDemo() {
  return (
    <Tabs defaultValue='comment' className='w-[400px]'>
      <TabsList className='grid w-full grid-cols-2'>
        <TabsTrigger value='comment'>Comment</TabsTrigger>
        <TabsTrigger value='history'>History</TabsTrigger>
      </TabsList>
      <TabsContent value='comment'>
        <CommentSection />
      </TabsContent>
      <TabsContent value='history'>
        <HistorySection />
      </TabsContent>
    </Tabs>
  );
}
