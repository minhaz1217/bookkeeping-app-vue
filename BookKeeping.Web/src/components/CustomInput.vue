<script lang="ts" setup>
    import { defineProps } from 'vue';

    const props = defineProps({
        value: Number,
        onChangeOrKeyUp : Function,

    });

    const emit = defineEmits(["customInputChanged"]);

    function onChangeOrKeyUp(e : any){
        let value = parseInt(e.target.value);
        if(!isNaN(value)){
            emit('customInputChanged', e.target.value);
        }
    }

    function onBlur(e : any){
        e.target.value = props.value;
    }
</script>

<template>
    <input type="number" @change="onChangeOrKeyUp" @keyup="onChangeOrKeyUp" :value="value" @blur="onBlur" />
</template>
