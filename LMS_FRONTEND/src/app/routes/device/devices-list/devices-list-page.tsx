import { Layout } from '@/components/layouts/default-layout';
import DevicesList from '@/features/device/devices-list/components/devices-list';

export function DevicesListPage() {
  return (
    <Layout>
      <DevicesList></DevicesList>
    </Layout>
  );
}

export default DevicesListPage;
