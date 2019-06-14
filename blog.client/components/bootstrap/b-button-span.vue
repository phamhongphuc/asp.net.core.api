<template>
    <span v-on-clickaway="clickaway" class="btn-span" @click="$emit('click')">
        <icon- v-if="icon" :i="icon" />
        <span v-if="text" class="pr-2">{{ text }}</span>
    </span>
</template>
<script lang="ts">
import { Component, mixins, Emit } from 'nuxt-property-decorator';
import { ClickawayMixin, IconProps, TextProps } from '~/components/mixins';

@Component({ name: 'b-button-span-' })
export default class extends mixins<ClickawayMixin, IconProps, TextProps>(
    ClickawayMixin,
    IconProps,
    TextProps,
) {
    @Emit('clickaway')
    clickaway() {}
}
</script>

<style lang="scss">
.btn-span {
    display: flex;
    border-radius: $border-radius-sm;
    cursor: pointer;
    &:hover {
        background-color: rgba($black, 0.125);
    }
    > .icon {
        min-width: 2rem;
        text-align: center;
    }
    > span {
        height: 2rem;
        line-height: 2rem;
    }
}
</style>
