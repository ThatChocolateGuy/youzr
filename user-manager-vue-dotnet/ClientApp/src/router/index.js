import { createWebHistory, createRouter } from "vue-router";
import Dashboard from "@/components/Dashboard.vue";
import Profile from "@/components/Profile.vue";
import Users from "@/components/Users.vue";

// handle redirect back from Okta
// import { LoginCallback } from '@okta/okta-vue'

const routes = [
    {
        path: "/",
        name: "Dashboard",
        component: Dashboard,
    },
    {
        path: "/profile",
        name: "Profile",
        component: Profile,
        // meta: {
        //     requiresAuth: true
        // }
    },
    {
        path: "/users",
        name: "Users",
        component: Users
        // meta: {
        //     requiresAuth: true
        // }
    },
    {
        path: "/new-user",
        name: "NewUser",
        component: () => import('@/components/NewUser.vue')
        // meta: {
        //     requiresAuth: true
        // }
    },
    {
        path: "/edit-user/:userId",
        name: "EditUser",
        component: () => import('@/components/EditUser.vue')
        // meta: {
        //     requiresAuth: true
        // }
    },
    // {
    //     path: '/login/callback',
    //     name: "LoginCallback",
    //     component: LoginCallback
    // },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;