<template>
    <div id="center">
        <div class="shadow-lg p-4 rounded m-2">
            <nuxt />
        </div>
    </div>
</template>
<style lang="scss">
#center {
    position: fixed;
    display: flex;
    align-items: center;
    justify-content: center;
    width: 100%;
    height: 100%;
    background-color: #34495e;
    background-image: url('https://source.unsplash.com/rtCujH697DU/1920x1080/?nature');
    background-position: center;
    background-size: cover;
    > div {
        background-color: rgba($black, 0.5);
    }
}
</style>
