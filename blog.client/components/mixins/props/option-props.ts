import { Vue, Prop, Component } from 'nuxt-property-decorator';

// Copy and convert from https://github.com/bootstrap-vue/bootstrap-vue/blob/dev/src/mixins/form-options.js
@Component
export class OptionProps extends Vue {
    @Prop({
        type: [Array, Object],
        default() {
            return [];
        },
    })
    protected options!: any;

    @Prop({ type: String, default: 'value' })
    protected valueField!: string;

    @Prop({
        type: String,
        default: 'text',
    })
    protected textField!: string;

    @Prop({
        type: String,
        default: 'html',
    })
    protected htmlField!: string;

    @Prop({
        type: String,
        default: 'disabled',
    })
    protected disabledField!: string;
}
