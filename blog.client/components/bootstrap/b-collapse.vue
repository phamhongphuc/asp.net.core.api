<template>
    <b-collapse
        v-if="isShow"
        :id="id"
        :visible="visible"
        @input="$emit('input', $event)"
    >
        <slot />
    </b-collapse>
</template>
<script lang="ts">
import { Component, Prop, Vue } from 'nuxt-property-decorator';

@Component({
    name: 'b-collapse-',
    model: {
        prop: 'visible',
        event: 'input',
    },
})
export default class extends Vue {
    @Prop({ default: false, type: Boolean })
    visible!: boolean;

    @Prop({ required: true, type: String, default: '' })
    id!: string;

    @Prop({ default: false, type: Boolean })
    autoPermission!: boolean;
}
</script>
