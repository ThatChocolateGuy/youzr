<template>
  <nav class="main-header navbar navbar-expand bg-white navbar-light border-bottom">
    <!-- Left navbar links -->
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link" @click="toggleMenuSidebar">
          <i class="fas fa-bars"></i>
        </a>
      </li>
    </ul>

    <ul class="navbar-nav ml-auto">
      <li class="nav-item">    
        <a class="nav-link" @click="logout" title="Log Out">
          <i class="fas fa-power-off"></i>
        </a>
      </li>
    </ul>
  </nav>
</template>

<script>
import UserService from "../../_services/users-service";
export default {
  name: "Header",
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
    async logout () {
      UserService.logout();
      window.location.reload();
    }
  }
};
</script>

<style>
.nav-link {
  cursor: pointer;
}
</style>

