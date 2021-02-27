<template>
  <div>
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Edit User</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item">
                <router-link :to="{ name: 'Dashboard' }">Home</router-link>
              </li>
              <li class="breadcrumb-item">
                <router-link :to="{ name: 'Users' }">Users</router-link>
              </li>
              <li class="breadcrumb-item active">Edit User</li>
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
                  @click="updateUser()"
                >
                  Update
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
    getUser() {
      axios
        .get(`/api/users/${this.$route.params.userId}`)
        .then((response) => {
          this.user = response.data;
          this.emailInput = this.user.email;
          this.passwordInput = this.user.password;
          this.nameInput = this.user.name;
          console.log(this.user);
        })
        .catch(function (error) {
          alert(error);
        });
    },
    updateUser() {
      axios
        .put(`/api/users/${this.user.userId}`, {
          userId: this.user.userId,
          email: this.emailInput,
          password: this.passwordInput,
          name: this.nameInput,
        })
        .then(() => {
          alert(`User ${this.user.name} updated!`);
          this.$router.push('/users');
        })
        .catch(function (error) {
          alert(error);
        });
    },
  },
  mounted() {
    this.getUser()
  }
};
</script>