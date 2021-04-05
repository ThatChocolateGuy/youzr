<template>
  <div>
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>User Management</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item">
                <router-link :to="{ name: 'Dashboard' }">Home</router-link>
              </li>
              <li class="breadcrumb-item active">Users</li>
            </ol>
          </div>
        </div>
      </div>
      <!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class="content">
      <router-link :to="{ name: 'NewUser' }">
        <button class="btn btn-success mx-3 mb-3">
          <b>New User</b>
        </button>
      </router-link>

      <p v-if="!users"><em>Loading...</em></p>

      <div class="container-fluid">
        <div class="row">
          <!-- Profile Card (use v-for each user) -->
          <div class="col-md-4 p-3" v-for="user of users" :key="user.userId">
            <!-- Profile Image -->
            <div class="card card-primary card-outline">
              <div class="card-body box-profile">
                <div class="text-center">
                  <img
                    class="profile-user-img img-fluid img-circle"
                    src="./../assets/img/default-user.png"
                    alt="User profile picture"
                  />
                </div>

                <h3 class="profile-username text-center">{{ user.name }}</h3>

                <p class="text-muted text-center">{{ user.email }}</p>

                <router-link
                  :to="{ name: 'EditUser', params: { userId: user.userId } }"
                >
                  <div class="btn col-sm-6 p-1">
                    <button class="btn btn-primary btn-block">
                      <b>Edit</b>
                    </button>
                  </div>
                </router-link>

                <div class="btn col-sm-6 p-1">
                  <button
                    class="btn btn-danger btn-block"
                    @click="deleteUser(user.userId)"
                  >
                    <b>Delete</b>
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
import UsersService from "../_services/users-service";
export default {
  data() {
    return {
      users: [],
      user: null,
    };
  },
  methods: {
    deleteUser(id) {
      UsersService.delete(id).then((user) => {
        this.user = user;
        console.log(user);
        this.getUsers();
      });
    },
    getUsers() {
      UsersService.getAll().then((users) => {
        this.users = users;
        console.log(users);
      });
    },
  },
  beforeMount() {
    this.getUsers();
  },
};
</script>