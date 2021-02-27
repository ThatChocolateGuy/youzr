<template>
  <div>
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>New User</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item">
                <router-link :to="{ name: 'Dashboard' }">Home</router-link>
              </li>
              <li class="breadcrumb-item">
                <router-link :to="{ name: 'Users' }">Users</router-link>
              </li>
              <li class="breadcrumb-item active">New User</li>
            </ol>
          </div>
        </div>
      </div>
      <!-- /.container-fluid -->
    </section>

    <div class="card m-3">
      <div class="card-header p-2">
        <ul class="nav nav-pills">
          <li class="nav-item"><a class="nav-link active">Info</a></li>
        </ul>
      </div>
      <div class="card-body">
        <div class="tab-content">
          <div class="tab-pane active">
            <form class="p-2">
              <div class="form-row">
                <div class="form-group col-sm-12 col-md-12">
                  <label>Name</label
                  ><input
                    name="name"
                    type="text"
                    class="form-control"
                    placeholder="Name"
                    v-model="nameInput"
                    autofocus
                  />
                </div>
                <div class="form-group col-sm-12 col-md-6">
                  <label>Email</label
                  ><input
                    name="email"
                    type="email"
                    class="form-control"
                    placeholder="Email"
                    v-model="emailInput"
                  />
                </div>
                <div class="form-group col-sm-12 col-md-6">
                  <label>Password</label
                  ><input
                    name="password"
                    type="password"
                    class="form-control"
                    placeholder="Password"
                    v-model="passwordInput"
                  />
                </div>
              </div>
              <hr />
              <div>
                <button
                  type="button"
                  class="btn btn-block btn-primary w-auto float-right"
                  @click="createUser()"
                >
                  Register
                </button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      user: null,
      emailInput: "",
      passwordInput: "",
      nameInput: "",
    };
  },
  methods: {
    createUser() {
      axios
        .post("/api/users", {
          email: this.emailInput,
          password: this.passwordInput,
          name: this.nameInput,
        })
        .then((response) => {
          this.user = response.data;
          console.log(this.user);
          alert(`User ${this.user.name} created!`);
          this.$router.push('/users');
        })
        .catch(function (error) {
          alert(error);
        });
    },
  },
};
</script>