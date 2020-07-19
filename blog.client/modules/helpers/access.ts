import { EnumAccess } from '~/types/rest';

interface SelectOption {
    value: string;
    text: string;
}

type EnumAccessMap = { [key in EnumAccess]: string };

export const enumAccessMap: EnumAccessMap = {
    [EnumAccess.Administrator]: 'Quản trị',
    [EnumAccess.Moderator]: 'Điều hành',
    [EnumAccess.NormalUser]: 'Thường',
    [EnumAccess.BannedUser]: 'Bị cấm',
};

export const AccessOptions: SelectOption[] = Object.keys(enumAccessMap).map(
    key => {
        return {
            value: key,
            text: enumAccessMap[key],
        };
    },
);
