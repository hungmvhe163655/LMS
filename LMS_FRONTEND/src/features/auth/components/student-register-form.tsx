import React from "react";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { Link } from "react-router-dom";
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Checkbox } from "@/components/ui/checkbox";
import { Button } from "@/components/ui/button";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { Link, useLocation } from "react-router-dom";

const FormSchema = z.object({
  email: z.string().min(6, {
    message: "Email must have more than 6 characters",
  }),
  password: z
    .string()
    .min(6, { message: "Password must have more than 6 characters" }),
  confirmPassword: z.string(),
  fullname: z
    .string()
    .min(3, { message: "Fullname must have more than 3 characters" }),
  supervisor: z.number(),
  phonenumber: z
    .string()
    .min(9, { message: "Phone number must have more than 9 characters" }),
});

const RegisterForm: React.FC = () => {
  const location = useLocation();
  const searchParams = new URLSearchParams(location.search);
  const studentCode = searchParams.get("studentCode");

  const form = useForm<z.infer<typeof FormSchema>>({
    resolver: zodResolver(FormSchema),
    defaultValues: {
      email: "",
      password: "",
      confirmPassword: "",
      fullname: "",
      supervisor: 0,
      phonenumber: "",
    },
  });

  function onSubmit(data: z.infer<typeof FormSchema>) {
    console.log(data);
    // Submit Logic
  }

  return (
    <div className="registerFormContainer">
      <Card className="card">
        <CardHeader>
          <CardTitle>Register</CardTitle>
          <CardDescription>
            Welcome to SAP Lab Management System
          </CardDescription>
        </CardHeader>
        <CardContent className="card-content">
          <Form {...form}>
            <form
              onSubmit={form.handleSubmit(onSubmit)}
              className="w-2/3 space-y-6"
            >
              {/* Display the student code */}
              {studentCode && (
                <div>
                  <p>Student Code: {studentCode}</p>
                </div>
              )}
              {/* Fullname input field */}
              <FormField
                control={form.control}
                name="fullname"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Fullname</FormLabel>
                    <FormControl>
                      <Input placeholder="Nguyen Van A" {...field} />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />

              {/* Email Input Field */}
              <FormField
                control={form.control}
                name="email"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Email</FormLabel>
                    <FormControl>
                      <Input placeholder="yourname@fpt.edu.vn" {...field} />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />

              {/* Phone Number Input Field */}
              <FormField
                control={form.control}
                name="phonenumber"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Phone Number</FormLabel>
                    <FormControl>
                      <Input placeholder="0912345678" {...field} />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />

              {/* Supervisor Input Field */}
              <FormField
                control={form.control}
                name="supervisor"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Supervisor ID</FormLabel>
                    <FormControl>
                      <Input
                        placeholder="This will later be a combobox when dev has his APIs"
                        {...field}
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />

              {/* Password Input Field */}
              <FormField
                control={form.control}
                name="password"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Password</FormLabel>
                    <FormControl>
                      <Input
                        type="password"
                        placeholder="Your password"
                        {...field}
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />

              {/* Confirm Password Input Field */}
              <FormField
                control={form.control}
                name="confirmPassword"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Confirm Password</FormLabel>
                    <FormControl>
                      <Input
                        type="password"
                        placeholder="Confirm your password"
                        {...field}
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />

              <div className="flex items-center space-x-2">
                <Checkbox id="terms" />
                <label
                  htmlFor="terms"
                  className="text-sm font-medium leading-none peer-disabled:cursor-not-allowed peer-disabled:opacity-70"
                >
                  I agree with Regulations Of SAP Laboratory.
                </label>
              </div>
              <Button type="submit">Submit</Button>
            </form>
          </Form>
        </CardContent>
        <CardFooter>
          <p>
            Already have an account?{" "}
            <Link className="registerLink" to="/">
              Login Here!
            </Link>
          </p>
        </CardFooter>
      </Card>{" "}
    </div>
  );
};

export default RegisterForm;
