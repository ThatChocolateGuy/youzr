
<template>
  <div class="login-wrapper">
    <div class="limiter">
      <div
        class="container-login100"
        style="background: url('./images/bg-01.jpg')"
      >
        <div class="wrap-login100">
          <div class="alert alert-warning mb-4">
            username: user1@user.com<br />
            password: user1pw
          </div>

          <form
            class="login100-form validate-form"
            @submit.prevent="handleSubmit"
          >
            <span class="login100-form-logo">
              <i class="zmdi zmdi-landscape"></i>
            </span>

            <span class="login100-form-title p-b-34 p-t-27"> Log in </span>

            <div
              class="wrap-input100 validate-input"
              data-validate="Enter username"
            >
              <input
                v-model="username"
                class="input100"
                :class="{ 'is-invalid': submitted && !username }"
                type="text"
                name="username"
                placeholder="Username"
              />
              <span class="focus-input100" data-placeholder="&#xf207;"></span>
              <div v-show="submitted && !username" class="invalid-feedback">
                Username is required
              </div>
            </div>

            <div
              class="wrap-input100 validate-input"
              data-validate="Enter password"
            >
              <input
                v-model="password"
                class="input100"
                :class="{ 'is-invalid': submitted && !password }"
                type="password"
                name="pass"
                placeholder="Password"
              />
              <span class="focus-input100" data-placeholder="&#xf191;"></span>
              <div v-show="submitted && !password" class="invalid-feedback">
                Password is required
              </div>
            </div>

            <!-- <div class="contact100-form-checkbox">
              <input
                class="input-checkbox100"
                id="ckb1"
                type="checkbox"
                name="remember-me"
              />
              <label class="label-checkbox100" for="ckb1"> Remember me </label>
            </div> -->

            <div class="container-login100-form-btn">
              <button class="login100-form-btn" :disabled="loading">
                Login
              </button>
              <img
                v-show="loading"
                src="data:image/gif;base64,R0lGODlhEAAQAPIAAP///wAAAMLCwkJCQgAAAGJiYoKCgpKSkiH/C05FVFNDQVBFMi4wAwEAAAAh/hpDcmVhdGVkIHdpdGggYWpheGxvYWQuaW5mbwAh+QQJCgAAACwAAAAAEAAQAAADMwi63P4wyklrE2MIOggZnAdOmGYJRbExwroUmcG2LmDEwnHQLVsYOd2mBzkYDAdKa+dIAAAh+QQJCgAAACwAAAAAEAAQAAADNAi63P5OjCEgG4QMu7DmikRxQlFUYDEZIGBMRVsaqHwctXXf7WEYB4Ag1xjihkMZsiUkKhIAIfkECQoAAAAsAAAAABAAEAAAAzYIujIjK8pByJDMlFYvBoVjHA70GU7xSUJhmKtwHPAKzLO9HMaoKwJZ7Rf8AYPDDzKpZBqfvwQAIfkECQoAAAAsAAAAABAAEAAAAzMIumIlK8oyhpHsnFZfhYumCYUhDAQxRIdhHBGqRoKw0R8DYlJd8z0fMDgsGo/IpHI5TAAAIfkECQoAAAAsAAAAABAAEAAAAzIIunInK0rnZBTwGPNMgQwmdsNgXGJUlIWEuR5oWUIpz8pAEAMe6TwfwyYsGo/IpFKSAAAh+QQJCgAAACwAAAAAEAAQAAADMwi6IMKQORfjdOe82p4wGccc4CEuQradylesojEMBgsUc2G7sDX3lQGBMLAJibufbSlKAAAh+QQJCgAAACwAAAAAEAAQAAADMgi63P7wCRHZnFVdmgHu2nFwlWCI3WGc3TSWhUFGxTAUkGCbtgENBMJAEJsxgMLWzpEAACH5BAkKAAAALAAAAAAQABAAAAMyCLrc/jDKSatlQtScKdceCAjDII7HcQ4EMTCpyrCuUBjCYRgHVtqlAiB1YhiCnlsRkAAAOwAAAAAAAAAAAA=="
              />
            </div>

            <div v-if="error" class="alert alert-danger mt-3">{{ error }}</div>
            <!-- <div class="text-center p-t-90">
              <a class="txt1" href="#"> Forgot Password? </a>
            </div> -->
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import UserService from "../../_services/users-service";
import 'jquery'

require("./vendor/jquery/jquery-3.2.1.min.js");
require("./vendor/animsition/js/animsition.min.js");
require("./vendor/bootstrap/js/popper.js");
require("bootstrap");
require("./js/main.js");

export default {
  data() {
    return {
      username: "",
      password: "",
      submitted: false,
      loading: false,
      returnUrl: "",
      error: "",
    };
  },
  created() {
    // reset login status
    UserService.logout();

    // get return url from route parameters or default to '/'
    this.returnUrl = this.$route.query.returnUrl || "/";
  },
  methods: {
    handleSubmit() {
      this.submitted = true;
      const { username, password } = this;

      // stop here if form is invalid
      if (!(username && password)) {
        return;
      }

      this.loading = true;
      UserService.login(username, password).then(
        () => this.$router.push(this.returnUrl),
        (error) => {
          this.error = error;
          this.loading = false;
        }
      );
    },
  },
};
</script>

<style scoped src="./fonts/iconic/css/material-design-iconic-font.min.css"></style>
<style scoped src="./css/util.css"></style>
<style scoped src="./css/main.css"></style>