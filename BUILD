cc_binary(
    name = "test_main",
    srcs = glob(["src/**/*.cpp"]) + glob(["src/**/*.hpp"]),
    deps = ["@higanbana//core:core", "@higanbana//graphics:graphics"],
    copts = select({
        "@bazel_tools//src/conditions:windows": ["/std:c++latest", "/arch:AVX2", "/permissive-", "/await", "/Z7", "-ftime-trace"],
        "//conditions:default": ["-std=c++2a", "-msse4.2", "-m64"],
    }),
    defines = ["_WIN64"],
    linkopts = select({
    "@bazel_tools//src/conditions:windows": ["/subsystem:WINDOWS", "/DEBUG"],
    "//conditions:default": ["-pthread"],
    }),  
)