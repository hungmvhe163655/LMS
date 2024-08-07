import { BaseLayout } from '@/components/layouts/base-layout';
import DevicesList from '@/features/device/devices-list/components/devices-list';

export function DevicesListPage() {
  return (
    <BaseLayout>
      <DevicesList></DevicesList>
    </BaseLayout>
  );
}

export default DevicesListPage;
