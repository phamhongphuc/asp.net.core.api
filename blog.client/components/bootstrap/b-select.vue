<template>
    <div :class="{ 'has-icon': icon !== null }" class="b-select">
        <icon- v-if="icon" :i="icon" />
        <b-form-select
            ref="input"
            :aria-invalid="ariaInvalid"
            :disabled-field="disabledField"
            :html-field="htmlField"
            :multiple="multiple"
            :options="options"
            :select-size="selectSize"
            :state="state"
            :text-field="textField"
            :value-field="valueField"
            :value="value"
            @input="$emit('input', $event)"
            @focus="$emit('update:focus', true)"
            @blur="$emit('update:focus', false)"
        />
    </div>
</template>
<script lang="ts">
import { Component, Prop, mixins } from 'nuxt-property-decorator';
import { IconProps, StateProps, OptionProps } from '~/components/mixins';

@Component({
    name: 'b-input-',
})
export default class extends mixins<IconProps, StateProps, OptionProps>(
    IconProps,
    StateProps,
    OptionProps,
) {
    @Prop({})
    value!: any;

    @Prop({
        type: Boolean,
        default: false,
    })
    multiple!: boolean;

    @Prop({
        type: Number,
        default: 0,
    })
    selectSize!: number;

    @Prop({
        type: [Boolean, String],
        default: false,
    })
    ariaInvalid!: boolean | string;
}
</script>
<style lang="scss">
$input-icon-margin-left: 0.25rem;

.b-select {
    position: relative;
    display: flex;
    transition: border 0.2s;
    > .icon {
        position: absolute;
        display: block;
        width: $input-height;
        min-width: $input-height;
        min-height: $input-height;
        font-size: 1rem;
        line-height: $input-height;
        text-align: center;
    }

    > input {
        flex-grow: 1;
        min-width: 0;
        padding-left: calc(
            #{$input-height-inner} + #{$input-height-border} - 0.125rem
        );
        border: none;
        outline: none;
        &:focus {
            outline: none;
        }
    }

    &.circle {
        &,
        select {
            border-radius: calc(0.5 * #{$input-height});
        }
        > .icon {
            margin-left: $input-icon-margin-left;
        }
    }

    &.has-icon {
        > select {
            padding-left: calc(
                #{$input-height-inner} + #{$input-height-border} + #{$input-icon-margin-left}
            );
        }
    }
}
</style>
