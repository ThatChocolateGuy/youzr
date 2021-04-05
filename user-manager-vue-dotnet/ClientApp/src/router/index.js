import { createWebHistory, createRouter } from "vue-router";
import Dashboard from "@/components/Dashboard.vue";
import Profile from "@/components/Profile.vue";
import Users from "@/components/Users.vue";
import Login from "@/components/login/Login";
import NewUser from "@/components/NewUser.vue";
import EditUser from "@/components/EditUser.vue";


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
    },
    {
        path: "/users",
        name: "Users",
        component: Users
    },
    {
        path: "/new-user",
        name: "NewUser",
        component: NewUser
    },
    {
        path: "/edit-user/:userId",
        name: "EditUser",
        component: EditUser
    },
    {
        path: '/login',
        name: "Login",
        component: Login
    },
    // otherwise redirect to NotFound
    // { path: '/:pathMatch(.*)*', name: 'NotFound', component: NotFound } // need to create NotFound.vue
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

router.beforeEach((to, from, next) => {
    // redirect to login page if not logged in and trying to access a restricted page
    const publicPages = ['/login'];
    const authRequired = !publicPages.includes(to.path);
    const loggedIn = localStorage.getItem('user');
    console.log(`authRequired: ${authRequired}`)
    console.log(`loggedIn: ${loggedIn}`)

    if (authRequired && !loggedIn) {
        console.log('authRequired && !loggedIn')
        return next({
            path: '/login',
            query: { returnUrl: to.path }
        });
    }

    next();
})

export default router;