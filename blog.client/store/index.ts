import { PostState } from './post';
import { AuthState } from './auth';

export interface RootState {
    post: PostState;
    auth: AuthState;
}
