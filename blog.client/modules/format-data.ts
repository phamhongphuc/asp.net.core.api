import moment from 'moment';

export function timeAgo(time: string) {
    return moment(time).fromNow();
}

export function defaultImageUrl(name: string) {
    return `https://ui-avatars.com/api/?name=${name}&font-size=0.4&bold=true&background=4398d1&color=ffffff`;
}
