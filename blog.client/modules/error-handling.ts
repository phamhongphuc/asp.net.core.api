import { BvToastOptions } from 'bootstrap-vue';
import Vue, { VNode } from 'vue';

type MessageType = string | VNode | VNode[];

type ToastType = { message: MessageType; options?: BvToastOptions };

interface TryCatchContext {
    handle: () => Promise<any> | any;
    success?: ToastType;
    fail?: ToastType;
}

export async function tryCatch(
    this: Vue,
    { handle, success, fail }: TryCatchContext,
) {
    const toast = (input: ToastType | undefined, options: BvToastOptions) => {
        if (!input) return;
        this.$bvToast.toast(input.message, { ...options, ...input.options });
    };

    try {
        await handle();
        toast(success, {
            title: 'Thông báo',
            variant: 'main',
        });
    } catch (e) {
        toast(fail, {
            title: 'Lỗi',
            variant: 'red',
        });
    }
}
