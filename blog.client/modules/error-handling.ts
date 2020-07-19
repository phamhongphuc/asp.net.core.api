import { AxiosError } from 'axios';
import { BvToastOptions } from 'bootstrap-vue';
import Vue, { VNode } from 'vue';
import { IErrorResponse } from '~/types/rest';

type MessageType = string | VNode | VNode[];

type ToastType = { message: MessageType; options?: BvToastOptions };

interface TryCatchContext<TData> {
    handle: () => Promise<TData> | TData;
    success?: ToastType;
    fail?: ToastType;
    onSuccess?: (result: TData) => Promise<any> | any;
    onFail?: (error: any) => any;
}

function isAxiosError(error: any): error is AxiosError<IErrorResponse> {
    return error.isAxiosError === true;
}

export async function $tryCatch<TData = any>(
    this: Vue,
    { handle, success, fail, onSuccess, onFail }: TryCatchContext<TData>,
) {
    const toast = (input: ToastType | undefined, options: BvToastOptions) => {
        if (!input) return;
        this.$bvToast.toast(input.message, { ...options, ...input.options });
    };

    try {
        const result = await handle();
        if (onSuccess) await onSuccess(result);
        toast(success, {
            title: 'Thông báo',
            variant: 'main',
        });
    } catch (error) {
        if (onFail) await onFail(error);
        let message = '';
        if (isAxiosError(error) && error.response) {
            message = error.response.data.description as string;
        }
        toast(
            { message, options: fail && fail.options },
            { title: 'Lỗi', variant: 'red' },
        );
    }
}
