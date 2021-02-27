<template>
  <div class="wrapper">
    <Header></Header>
    <SidebarMenu></SidebarMenu>

    <div class="content-wrapper">
      <router-view />
    </div>

    <Footer></Footer>

    <aside class="control-sidebar control-sidebar-dark"></aside>
    <div id="sidebar-overlay" v-on:click="toggleMenuSidebar"></div>
  </div>
</template>

<script>
import Header from "./components/layout/Header";
import SidebarMenu from "./components/layout/SidebarMenu";
import Footer from "./components/layout/Footer";
import axios from "axios";

export default {
  name: "App",
  components: {
    Header,
    SidebarMenu,
    Footer,
  },
  data() {
    return {
      user: null,
      users: []
    };
  },
  methods: {
    toggleMenuSidebar() {
      if (document.body.classList.contains("sidebar-open")) {
        document.body.classList.remove("sidebar-open");
        document.body.classList.add("sidebar-collapse");
      } else if (document.body.classList.contains("sidebar-collapse")) {
        document.body.classList.remove("sidebar-collapse");
        document.body.classList.add("sidebar-open");
      }
    },
    getUsers() {
      axios
        .get("/api/users")
        .then((response) => {
          this.users = response.data;
          console.log(this.users);
          if (this.users.length == 0) this.seedUsers();
        })
        .catch(function (error) {
          alert(error);
        });
    },
    createUser(user) {
      axios
        .post("/api/users", {
          email: user.email,
          password: user.password,
          name: user.name,
        })
        .then((response) => {
          this.user = response.data;
          console.log(`User ${this.user.name} created!`);
        })
        .catch(function (error) {
          alert(error);
        });
    },
    seedUsers() {
      const seedData = [
        {
          email: "user1@user.com",
          password: "user1pw",
          name: "user 1",
        },
        {
          email: "user2@user.com",
          password: "user2pw",
          name: "user 2",
        },
        {
          email: "user3@user.com",
          password: "user3pw",
          name: "user 3",
        },
      ];

      seedData.forEach(user => {
        this.createUser(user)
      });
      console.log('user database seeded')
    },
  },
  mounted() {
    this.getUsers();
  }
};
</script>

<style>
@import url("https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css");
@import url("https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700");
@import url("../node_modules/bootstrap/dist/css/bootstrap.min.css");
@import url("../node_modules/admin-lte/dist/css/adminlte.min.css");
@import url("../node_modules/@fortawesome/fontawesome-free/css/all.min.css");
</style>
